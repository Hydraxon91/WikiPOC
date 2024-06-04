using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wiki_backend.Controllers;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.Models;

namespace IntegrationTests.ControllerTests.CategoryControllerTests;

[TestFixture]
public class CategoryControllerTests : IntegrationTestBase
{
    private CategoryRepository _categoryRepository;
    private CategoryController _controller;
    
    [SetUp]
    public async Task SetUp()
    {
        _categoryRepository = new CategoryRepository(DbContext);
        _controller = new CategoryController(_categoryRepository);
        ResetDatabase();
        await EnsureUserRoleExistsAsync();
    }

    [Test]
    public async Task GetAllCategories_Should_Return_All_Categories()
    {
        // Arrange
        var categories = new List<Category>
        {
            new Category
            {
               Id = Guid.NewGuid(),
               CategoryName = "Test Category 1"
            },
            new Category
            {
                Id = Guid.NewGuid(),
                CategoryName = "Test Category 2"
            },
            new Category
            {
                Id = Guid.NewGuid(),
                CategoryName = "Test Category 3"
            }
        };
        await DbContext.Categories.AddRangeAsync(categories);
        await DbContext.SaveChangesAsync();
        
        // Act
        var result = await _controller.GetAllCategories();
        // Assert
        var okResult = result.Result as OkObjectResult;
        Assert.IsNotNull(okResult);
        Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
    }

    [Test]
    public async Task GetCategoryByName_Should_Return_Correct_Category()
    {
        // Arrange
        var categoryName = "testCategory";
        var catId = Guid.NewGuid();
        var categories = new List<Category>
        {
            new Category
            {
                Id = catId,
                CategoryName = categoryName
            },
            new Category
            {
                Id = Guid.NewGuid(),
                CategoryName = "Test Category 2"
            },
            new Category
            {
                Id = Guid.NewGuid(),
                CategoryName = "Test Category 3"
            }
        };
        await DbContext.Categories.AddRangeAsync(categories);
        await DbContext.SaveChangesAsync();
        
        // Act
        var result = await _controller.GetCategoryByName(categoryName);
        
        // Assert
        var okResult = result.Result as OkObjectResult;
        Assert.IsNotNull(okResult);
        Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
        
        var category = okResult.Value as Category;
        Console.WriteLine(category);
        Assert.AreEqual(catId, category.Id);
        Assert.AreEqual(categoryName, category.CategoryName);
    }

    [Test]
    public async Task AddCategory_Should_Add_Category()
    {
        // Arrange
        var categoryName = "testCategory";
        var email = "Add@category.com";
        var username = "Addcategoryman";
        var password = "@Addcategory1";
        await CreateAdminUserAsync(email, username, password);
        var token = await GetValidUserToken(email, username, password);
        _controller.ControllerContext.HttpContext = new DefaultHttpContext
        {
            Request = { Headers = { ["Authorization"] = $"Bearer {token}" } }
        };
        
        // Act
        await _controller.AddCategory(categoryName);
        
        // Assert
        var category = await DbContext.Categories.FirstOrDefaultAsync(c => c.CategoryName == categoryName);
        Assert.IsNotNull(category);
        Assert.AreEqual(categoryName, category.CategoryName);
    }

    [Test]
    public async Task DeleteCategory_Should_Delete_Category()
    {
        // Arrange
        var categoryName = "testCategory";
        var catId = Guid.NewGuid();
        var categories = new List<Category>
        {
            new Category
            {
                Id = catId,
                CategoryName = categoryName
            },
            new Category
            {
                Id = Guid.NewGuid(),
                CategoryName = "Test Category 2"
            },
            new Category
            {
                Id = Guid.NewGuid(),
                CategoryName = "Test Category 3"
            }
        };
        
        await DbContext.Categories.AddRangeAsync(categories);
        await DbContext.SaveChangesAsync();
        var email = "Add@category.com";
        var username = "Addcategoryman";
        var password = "@Addcategory1";
        await CreateAdminUserAsync(email, username, password);
        var token = await GetValidUserToken(email, username, password);
        _controller.ControllerContext.HttpContext = new DefaultHttpContext
        {
            Request = { Headers = { ["Authorization"] = $"Bearer {token}" } }
        };
        
        // Act
        var predeleteCategories = await DbContext.Categories.ToListAsync();
        var oldCatsLength = predeleteCategories.Count;
        var result = await _controller.DeleteCategory(catId);
        
        // Assert
        var okResult = result as OkObjectResult;
        Assert.IsNotNull(okResult);
        Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);

        var dbCategories = await DbContext.Categories.ToListAsync();
        Assert.IsFalse(dbCategories.Any(c => c.CategoryName == categoryName));
        Assert.IsFalse(dbCategories.Count == oldCatsLength);
    }
}