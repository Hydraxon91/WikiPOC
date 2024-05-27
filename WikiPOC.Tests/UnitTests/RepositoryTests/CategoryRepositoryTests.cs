using Microsoft.EntityFrameworkCore;
using wiki_backend.DatabaseServices;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.Models;

namespace UnitTests.RepositoryTests;

[TestFixture]
public class CategoryRepositoryTests
{
    private CategoryRepository _categoryRepository;
    private WikiDbContext _wikiDbContext;
    
    [SetUp]
    public void Setup()
    {
        // Generate a unique database name based on the test name
        var databaseName = $"TestDatabase_{TestContext.CurrentContext.Test.Name}";
        // Use an in-memory database for testing
        var options = new DbContextOptionsBuilder<WikiDbContext>()
            .UseInMemoryDatabase(databaseName: databaseName)
            .Options;

        // Use AddDbContext to configure the WikiDbContext
        _wikiDbContext = new WikiDbContext(options, configuration: null); 
        _wikiDbContext.Database.EnsureCreated(); // Ensure the in-memory database is created
        _wikiDbContext.Database.EnsureDeleted();
        _categoryRepository = new CategoryRepository(_wikiDbContext);
    }
    
    [TearDown]
    public void TearDown()
    {
        // Dispose the context to release the in-memory database
        _wikiDbContext.Database.EnsureDeleted();
        _wikiDbContext.Dispose();
    }
    
    [Test]
    public async Task AddCategoryAsync_ShouldAddCategory()
    {
        var categoryName = "Test Category";

        await _categoryRepository.AddCategoryAsync(categoryName);

        var categoryInDb = await _wikiDbContext.Categories.FirstOrDefaultAsync(c => c.CategoryName == categoryName);

        Assert.NotNull(categoryInDb);
        Assert.AreEqual(categoryName, categoryInDb.CategoryName);
    }
    
    [Test]
    public void AddCategoryAsync_ShouldThrowArgumentException_WhenCategoryExists()
    {
        var categoryName = "Existing Category";

        // Add initial category
        Assert.DoesNotThrowAsync(async () => await _categoryRepository.AddCategoryAsync(categoryName));

        // Try adding the same category again
        Assert.ThrowsAsync<ArgumentException>(async () => await _categoryRepository.AddCategoryAsync(categoryName));
    }
    
    [Test]
    public async Task GetCategoryByNameAsync_ShouldReturnCategory()
    {
        var categoryName = "Test Category";
        await _categoryRepository.AddCategoryAsync(categoryName);

        var category = await _categoryRepository.GetCategoryByNameAsync(categoryName);

        Assert.NotNull(category);
        Assert.AreEqual(categoryName, category.CategoryName);
    }

    [Test]
    public async Task GetAllCategoriesAsync_ShouldReturnAllCategories()
    {
        var categoryName1 = "Category 1";
        var categoryName2 = "Category 2";
        await _categoryRepository.AddCategoryAsync(categoryName1);
        await _categoryRepository.AddCategoryAsync(categoryName2);

        var categories = await _categoryRepository.GetAllCategoriesAsync();

        Assert.AreEqual(2, categories.Count());
    }

    [Test]
    public async Task DeleteCategoryAsync_ShouldDeleteCategory()
    {
        var categoryName = "Category to Delete";
        var category = await _categoryRepository.AddCategoryAsync(categoryName);

        var result = await _categoryRepository.DeleteCategoryAsync(category.Id);

        var categoryInDb = await _wikiDbContext.Categories.FindAsync(category.Id);

        Assert.IsTrue(result);
        Assert.Null(categoryInDb);
    }

    [Test]
    public async Task DeleteCategoryAsync_ShouldReturnFalse_WhenCategoryNotFound()
    {
        var result = await _categoryRepository.DeleteCategoryAsync(Guid.NewGuid());

        Assert.IsFalse(result);
    }

    [Test]
    public async Task AddArticleToCategoryAsync_ShouldAddArticleToCategory()
    {
        var categoryName = "Category with Article";
        var category = await _categoryRepository.AddCategoryAsync(categoryName);

        var wikiPage = new WikiPage
        {
            Id = Guid.NewGuid(),
            Title = "New Article"
        };

        await _categoryRepository.AddArticleToCategoryAsync(category.Id, wikiPage);

        var categoryInDb = await _wikiDbContext.Categories
            .Include(c => c.WikiPages)
            .FirstOrDefaultAsync(c => c.Id == category.Id);

        Assert.NotNull(categoryInDb);
        Assert.AreEqual(1, categoryInDb.WikiPages.Count);
        Assert.AreEqual("New Article", categoryInDb.WikiPages.First().Title);
    }

    [Test]
    public async Task RemoveArticleFromCategoryAsync_ShouldRemoveArticleFromCategory()
    {
        var categoryName = "Category with Article";
        var category = await _categoryRepository.AddCategoryAsync(categoryName);

        var wikiPage = new WikiPage
        {
            Id = Guid.NewGuid(),
            Title = "Article to Remove"
        };

        await _categoryRepository.AddArticleToCategoryAsync(category.Id, wikiPage);

        await _categoryRepository.RemoveArticleFromCategoryAsync(category.Id, wikiPage.Id);

        var categoryInDb = await _wikiDbContext.Categories
            .Include(c => c.WikiPages)
            .FirstOrDefaultAsync(c => c.Id == category.Id);

        Assert.NotNull(categoryInDb);
        Assert.AreEqual(0, categoryInDb.WikiPages.Count);
    }
}
