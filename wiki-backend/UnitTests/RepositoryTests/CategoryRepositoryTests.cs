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
        var databaseName = $"TestDatabase_{TestContext.CurrentContext.Test.Name}";
        var options = new DbContextOptionsBuilder<WikiDbContext>()
            .UseInMemoryDatabase(databaseName: databaseName)
            .Options;

        _wikiDbContext = new WikiDbContext(options, configuration: null!);
        _wikiDbContext.Database.EnsureCreated();
        _wikiDbContext.Database.EnsureDeleted();
        _categoryRepository = new CategoryRepository(_wikiDbContext);
    }

    [TearDown]
    public void TearDown()
    {
        _wikiDbContext.Database.EnsureDeleted();
        _wikiDbContext.Dispose();
    }

    [Test]
    public async Task AddCategoryAsync_ShouldAddCategory()
    {
        var categoryName = "Test Category";

        await _categoryRepository.AddCategoryAsync(categoryName);

        var categoryInDb = await _wikiDbContext.Categories.FirstOrDefaultAsync(c => c.CategoryName == categoryName);

        Assert.That(categoryInDb, Is.Not.Null);
        Assert.That(categoryInDb.CategoryName, Is.EqualTo(categoryName));
    }

    [Test]
    public void AddCategoryAsync_ShouldThrowArgumentException_WhenCategoryExists()
    {
        var categoryName = "Existing Category";

        Assert.DoesNotThrowAsync(async () => await _categoryRepository.AddCategoryAsync(categoryName));
        Assert.ThrowsAsync<ArgumentException>(async () => await _categoryRepository.AddCategoryAsync(categoryName));
    }

    [Test]
    public async Task GetCategoryByNameAsync_ShouldReturnCategory()
    {
        var categoryName = "Test Category";
        await _categoryRepository.AddCategoryAsync(categoryName);

        var category = await _categoryRepository.GetCategoryByNameAsync(categoryName);

        Assert.That(category, Is.Not.Null);
        Assert.That(category.CategoryName, Is.EqualTo(categoryName));
    }

    [Test]
    public async Task GetAllCategoriesAsync_ShouldReturnAllCategories()
    {
        var categoryName1 = "Category 1";
        var categoryName2 = "Category 2";
        await _categoryRepository.AddCategoryAsync(categoryName1);
        await _categoryRepository.AddCategoryAsync(categoryName2);

        var categories = await _categoryRepository.GetAllCategoriesAsync();

        Assert.That(categories.Count(), Is.EqualTo(2));
    }

    [Test]
    public async Task DeleteCategoryAsync_ShouldDeleteCategory()
    {
        var categoryName = "Category to Delete";
        var category = await _categoryRepository.AddCategoryAsync(categoryName);

        var result = await _categoryRepository.DeleteCategoryAsync(category.Id);

        var categoryInDb = await _wikiDbContext.Categories.FindAsync(category.Id);

        Assert.That(result, Is.True);
        Assert.That(categoryInDb, Is.Null);
    }

    [Test]
    public async Task DeleteCategoryAsync_ShouldReturnFalse_WhenCategoryNotFound()
    {
        var result = await _categoryRepository.DeleteCategoryAsync(Guid.NewGuid());

        Assert.That(result, Is.False);
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

        Assert.That(categoryInDb, Is.Not.Null);
        Assert.That(categoryInDb.WikiPages.Count, Is.EqualTo(1));
        Assert.That(categoryInDb.WikiPages.First().Title, Is.EqualTo("New Article"));
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

        Assert.That(categoryInDb, Is.Not.Null);
        Assert.That(categoryInDb.WikiPages.Count, Is.EqualTo(0));
    }
}
