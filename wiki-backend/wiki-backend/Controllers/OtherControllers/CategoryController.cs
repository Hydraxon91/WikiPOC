using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.Identity;
using wiki_backend.Models;

namespace wiki_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
    {
        var categories = await _categoryRepository.GetAllCategoriesAsync();
        return Ok(categories);
    }

    [HttpGet("{categoryName}")]
    public async Task<ActionResult<Category>> GetCategoryByName(string categoryName)
    {
        var category = await _categoryRepository.GetCategoryByNameAsync(categoryName);
        if (category == null)
        {
            return NotFound(); // Category not found
        }

        return Ok(category);
    }

    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpPost]
    public async Task<ActionResult<Category>> AddCategory([FromBody] string categoryName)
    {
        try
        {
            var newCategory = await _categoryRepository.AddCategoryAsync(categoryName);
            return CreatedAtAction(nameof(GetCategoryByName), new { categoryName = newCategory.CategoryName }, newCategory);
        }
        catch (ArgumentException ex)
        {
            return Conflict(ex.Message); // Category already exists
        }
    }

    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpDelete("{categoryId}")]
    public async Task<ActionResult> DeleteCategory(Guid categoryId)
    {
        var result = await _categoryRepository.DeleteCategoryAsync(categoryId);
        if (!result)
        {
            return NotFound(); // Category not found
        }

        return Ok(result); // Category deleted successfully
    }
}