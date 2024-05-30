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
        Assert.IsNotNull(result);
        CollectionAssert.AreEquivalent(expectedCategories, result);
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
        Assert.IsNotNull(result);
        Assert.AreEqual(expectedCategory, result);
    }

    [Test]
    public async Task AddCategoryAsync_ShouldAddCategory()
    {
        // Arrange
        var categoryName = "New Category";

        // Act
        var result = await _repository.AddCategoryAsync(categoryName);

        // Assert
        var addedCategory = await DbContext.Categories.FirstOrDefaultAsync(c => c.CategoryName == categoryName);
        Assert.IsNotNull(addedCategory);
        Assert.AreEqual(categoryName, addedCategory.CategoryName);
    }

    [Test]
    public async Task DeleteCategoryAsync_ShouldDeleteCategory()
    {
        // Arrange
        var categoryToDelete = await AddSampleCategoryToDatabase();

        // Act
        var result = await _repository.DeleteCategoryAsync(categoryToDelete.Id);

        // Assert
        Assert.IsTrue(result);
        var deletedCategory = await DbContext.Categories.FindAsync(categoryToDelete.Id);
        Assert.IsNull(deletedCategory);
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
        Assert.IsNotNull(updatedCategory);
        Assert.IsTrue(updatedCategory.WikiPages.Contains(wikiPage));
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
        Assert.IsNotNull(updatedCategory);
        Assert.IsFalse(updatedCategory.WikiPages.Contains(wikiPage));
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