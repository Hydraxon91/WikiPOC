using Microsoft.EntityFrameworkCore;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.Models;

namespace IntegrationTests.CategoryRepositoryTests;

[TestFixture]
public class CategoryRepositoryTests : IntegrationTestBase
{
    private CategoryRepository _repository;
    [SetUp]
    public void SetUp()
    {
        ResetDatabase(); // Ensure a clean database for each test
        _repository = new CategoryRepository(DbContext);
    }

    [Test]
    public async Task GetAllCategoriesAsync_ShouldReturnAllCategories()
    {
        // Arrange
        await AddSampleCategoriesToDatabase();
        var expectedCategories = await DbContext.Categories.ToListAsync();

        // Act
        var result = await _repository.GetAllCategoriesAsync();

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.EquivalentTo(expectedCategories));
    }

    [Test]
    public async Task GetCategoryByNameAsync_ShouldReturnCategory()
    {
        // Arrange
        await AddSampleCategoriesToDatabase();
        var categoryName = "Category 1";
        var expectedCategory = await DbContext.Categories.FirstOrDefaultAsync(c => c.CategoryName == categoryName);

        // Act
        var result = await _repository.GetCategoryByNameAsync(categoryName);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.EqualTo(expectedCategory));
    }

    [Test]
    public async Task AddCategoryAsync_ShouldAddCategory()
    {
        // Arrange
        var categoryName = "New Category";

        // Act
        await _repository.AddCategoryAsync(categoryName);

        // Assert
        var addedCategory = await DbContext.Categories.FirstOrDefaultAsync(c => c.CategoryName == categoryName);
        Assert.That(addedCategory, Is.Not.Null);
        Assert.That(addedCategory.CategoryName, Is.EqualTo(categoryName));
    }
    
    

    [Test]
    public async Task DeleteCategoryAsync_ShouldDeleteCategory()
    {
        // Arrange
        var categoryToDelete = await AddSampleCategoryToDatabase();

        // Act
        var result = await _repository.DeleteCategoryAsync(categoryToDelete.Id);

        // Assert
        Assert.That(result, Is.True);
        var deletedCategory = await DbContext.Categories.FindAsync(categoryToDelete.Id);
        Assert.That(deletedCategory, Is.Null);
    }
    
    [Test]
    public async Task DeleteCategoryAsync_ShouldReturnFalse_WhenCategoryNotFound()
    {
        // Arrange
        var categoryId = Guid.NewGuid(); // Generate a random non-existent category ID

        // Act
        var result = await _repository.DeleteCategoryAsync(categoryId);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public async Task AddArticleToCategoryAsync_ShouldAddArticleToCategory()
    {
        // Arrange
        var category = await AddSampleCategoryToDatabase();
        var wikiPage = new WikiPage { Title = "Test Article", Content = "Test Content" };

        // Act
        await _repository.AddArticleToCategoryAsync(category.Id, wikiPage);

        // Assert
        var updatedCategory = await DbContext.Categories.Include(c => c.WikiPages).FirstOrDefaultAsync(c => c.Id == category.Id);
        Assert.That(updatedCategory, Is.Not.Null);
        Assert.That(updatedCategory.WikiPages, Does.Contain(wikiPage));
    }

    [Test]
    public async Task RemoveArticleFromCategoryAsync_ShouldRemoveArticleFromCategory()
    {
        // Arrange
        var category = await AddSampleCategoryToDatabase();
        var wikiPage = new WikiPage { Title = "Test Article", Content = "Test Content" };
        await _repository.AddArticleToCategoryAsync(category.Id, wikiPage);

        // Act
        await _repository.RemoveArticleFromCategoryAsync(category.Id, wikiPage.Id);

        // Assert
        var updatedCategory = await DbContext.Categories.Include(c => c.WikiPages).FirstOrDefaultAsync(c => c.Id == category.Id);
        Assert.That(updatedCategory, Is.Not.Null);
        Assert.That(updatedCategory.WikiPages, Does.Not.Contain(wikiPage));
    }

    private async Task<Category> AddSampleCategoryToDatabase()
    {
        var category = new Category { CategoryName = "Sample Category" };
        await DbContext.Categories.AddAsync(category);
        await DbContext.SaveChangesAsync();
        return category;
    }

    private async Task AddSampleCategoriesToDatabase()
    {
        var categories = new List<Category>
        {
            new Category { CategoryName = "Category 1" },
            new Category { CategoryName = "Category 2" },
            new Category { CategoryName = "Category 3" }
        };
        await DbContext.Categories.AddRangeAsync(categories);
        await DbContext.SaveChangesAsync();
    }
}