using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.Identity;
using wiki_backend.Models;

namespace wiki_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WikiPagesController : ControllerBase
{
    private readonly IWikiPageRepository _wikiPageRepository;
    private readonly ICategoryRepository _categoryRepository;
    
    public WikiPagesController(IWikiPageRepository wikiPageRepository, ICategoryRepository categoryRepository)
    {
        _wikiPageRepository = wikiPageRepository;
        _categoryRepository = categoryRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<WikiPage>>> GetWikiPages()
    {
        var wikiPages = await _wikiPageRepository.GetAllAsync();
        return Ok(wikiPages);
    }
    
    [HttpGet("GetTitles")]
    public async Task<ActionResult<List<TitleAndCategory>>> GetWikiPageTitles()
    {
        var wikiPageTitlesAndCategories = await _wikiPageRepository.GetAllTitlesAndCategoriesAsync();
        return Ok(wikiPageTitlesAndCategories);
    }

    [HttpGet("GetById/{id:guid}")]
    public async Task<ActionResult<WPWithImagesOutputModel>> GetWikiPage(Guid id)
    {
        var wikiPage = await _wikiPageRepository.GetByIdAsync(id);

        if (wikiPage == null)
            return NotFound();

        return Ok(wikiPage);
    }
    
    [HttpGet("GetByTitle/{title}")]
    public async Task<ActionResult<WPWithImagesOutputModel>> GetWikiPageByTitle(string title)
    {
        var wikiPage = await _wikiPageRepository.GetByTitleAsync(title);

        if (wikiPage == null)
        {
            return NotFound(); // Return 404 if the page is not found
        }

        return Ok(wikiPage);
    }
    
    [HttpGet("{id:guid}/paragraphs")]
    public async Task<ActionResult<IEnumerable<Paragraph>>> GetWikiPageParagraphs(Guid id)
    {
        var wikiPageOutputModel = await _wikiPageRepository.GetByIdAsync(id);

        if (wikiPageOutputModel == null)
            return NotFound();

        // Check if Paragraphs is null, and return an empty list if it is
        var paragraphs = wikiPageOutputModel.WikiPage.Paragraphs ?? new List<Paragraph>();

        return Ok(paragraphs);
    }

    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpPost("admin")]
    public async Task<ActionResult<WikiPage>> CreateWikiPageForAdmin([FromForm] WikiPageWithImagesInputModel wikiPageWithImagesInputModel)
    {
        if (wikiPageWithImagesInputModel.Title == null)
        {
            return BadRequest("Invalid request. Title is null.");
        }

        var newWikiPage = new WikiPage
        {
            Id = Guid.NewGuid(),
            Title = wikiPageWithImagesInputModel.Title,
            SiteSub = wikiPageWithImagesInputModel.SiteSub,
            RoleNote = wikiPageWithImagesInputModel.RoleNote,
            Content = wikiPageWithImagesInputModel.Content,
            Paragraphs = wikiPageWithImagesInputModel.Paragraphs,
            CategoryId = wikiPageWithImagesInputModel.CategoryId
        };
        var images = wikiPageWithImagesInputModel.Images ?? new List<ImageFormModel>();
        
        try
        {
            await _wikiPageRepository.AddAsync(newWikiPage, images);
            return Ok(new { Message = "Article submitted successfully" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while submitting the article: {ex.Message}");
        }
    }
    
    [Authorize(Policy = IdentityData.UserPolicyName)]
    [HttpPost("user")]
    public async Task<ActionResult<WikiPage>> CreateWikiPageForUser([FromForm] WikiPageWithImagesInputModel wikiPageWithImagesInputModel)
    {
        if (wikiPageWithImagesInputModel.Title == null)
        {
            return BadRequest("Invalid request. Title is null.");
        }
        
        var newWikiPage = new UserSubmittedWikiPage
        {
            Id = Guid.NewGuid(),
            Title = wikiPageWithImagesInputModel.Title,
            SiteSub = wikiPageWithImagesInputModel.SiteSub,
            RoleNote = wikiPageWithImagesInputModel.RoleNote,
            Content = wikiPageWithImagesInputModel.Content,
            Paragraphs = wikiPageWithImagesInputModel.Paragraphs,
            IsNewPage = true,
            Approved = false,
            CategoryId = wikiPageWithImagesInputModel.CategoryId,
            SubmittedBy = wikiPageWithImagesInputModel.SubmittedBy,
            PostDate = DateTime.Now
        };
        
        var images = wikiPageWithImagesInputModel.Images ?? new List<ImageFormModel>();
        
        await _wikiPageRepository.AddUserSubmittedPageAsync(newWikiPage, images);

        return CreatedAtAction(nameof(GetWikiPage), new { id = newWikiPage.Id }, newWikiPage);
    }
    
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpPost("AdminAccept")]
    public async Task<ActionResult<WikiPage>> AcceptCreatedPageForUser([FromBody] string id)
    {
        var guid = Guid.Parse(id);
        var userSubmittedWikiPage = await _wikiPageRepository.GetSubmittedPageByIdAsync(guid);

        if (userSubmittedWikiPage is { UserSubmittedWikiPage: null })
        {
            return NotFound(); // Return 404 if the user-submitted page is not found
        }

        // Update the Approved property to true
        userSubmittedWikiPage.UserSubmittedWikiPage.Approved = true;

        // Save the changes to the database
        await _wikiPageRepository.AcceptUserSubmittedWikiPage(userSubmittedWikiPage.UserSubmittedWikiPage);

        return Ok(new { Message = "UserSubmittedWikiPage approved successfully" });
    }
    
    
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpPut("admin/{id:guid}")]
    public async Task<IActionResult> UpdateWikiPageForAdmin(Guid id, [FromForm] WikiPageWithImagesInputModel wikiPageWithImagesInputModel)
    {
        var existingWikiPageOutputModel = await _wikiPageRepository.GetByIdAsync(id);

        if (existingWikiPageOutputModel == null)
            return NotFound();

        if (wikiPageWithImagesInputModel.CategoryId != null)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(wikiPageWithImagesInputModel.CategoryId.Value);
            if (category == null)
                return BadRequest(new { Message = "Invalid CategoryId" });
        }

        var updatedWikiPage = new WikiPage
        {
            Title = wikiPageWithImagesInputModel.Title,
            SiteSub = wikiPageWithImagesInputModel.SiteSub,
            RoleNote = wikiPageWithImagesInputModel.RoleNote,
            Content = wikiPageWithImagesInputModel.Content,
            Paragraphs = wikiPageWithImagesInputModel.Paragraphs,
            CategoryId = wikiPageWithImagesInputModel.CategoryId,
            LegacyWikiPage = wikiPageWithImagesInputModel.LegacyWikiPage
        };

        var images = wikiPageWithImagesInputModel.Images ?? new List<ImageFormModel>();
        await _wikiPageRepository.UpdateAsync(existingWikiPageOutputModel.WikiPage, updatedWikiPage, images);

        return Ok(new { Message = "WikiPage updated successfully" });
    }

    
    //This method returns 400 for some reason, will need to check later
    [Authorize(Policy = IdentityData.UserPolicyName)]
    [HttpPut("userUpdate/{id:guid}")]
    public async Task<IActionResult> UpdateWikiPageForUser(Guid id, [FromForm] WikiPageWithImagesInputModel wikiPageWithImagesInputModel)
    {
        var updatedWikiPage = new UserSubmittedWikiPage()
        {
            Title = wikiPageWithImagesInputModel.Title,
            SiteSub = wikiPageWithImagesInputModel.SiteSub,
            RoleNote = wikiPageWithImagesInputModel.RoleNote,
            Content = wikiPageWithImagesInputModel.Content,
            Paragraphs = wikiPageWithImagesInputModel.Paragraphs,
            CategoryId = wikiPageWithImagesInputModel.CategoryId,
            LegacyWikiPage = wikiPageWithImagesInputModel.LegacyWikiPage,
            SubmittedBy = wikiPageWithImagesInputModel.SubmittedBy,
            Approved = false,
            IsNewPage = false,
            WikiPageId = wikiPageWithImagesInputModel.WikiPageId
        };
        
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            return BadRequest(errors);
        }
        
        updatedWikiPage.Id = Guid.NewGuid();
        updatedWikiPage.PostDate = DateTime.Now;
        var images = wikiPageWithImagesInputModel.Images ?? new List<ImageFormModel>();
        await _wikiPageRepository.UserSubmittedUpdateAsync(updatedWikiPage, images);

        return CreatedAtAction(nameof(GetWikiPage), new { id = updatedWikiPage.Id }, updatedWikiPage);
    }
    
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpPatch("AdminAccept/{id:guid}")]
    public async Task<IActionResult> AcceptUpdateWikiPageForUser(Guid id)
    {
        // WikiPage updatedWikiPage = userSubmittedWikiPage;

        var newWikipage = await _wikiPageRepository.GetSubmittedUpdateByIdAsync(id);
        if ( newWikipage.UserSubmittedWikiPage.WikiPageId == null)
            return NotFound();
        
        var oldId = newWikipage.UserSubmittedWikiPage.WikiPageId ?? Guid.Empty; // Provide a default value
        var existingWikiPage = await _wikiPageRepository.GetByIdAsync(oldId);
        if ( existingWikiPage == null)
            return NotFound();
        
        await _wikiPageRepository.AcceptUserSubmittedUpdateAsync(newWikipage.UserSubmittedWikiPage);
        // await _wikiPageRepository.DeleteUserSubmittedAsync(newWikipage.UserSubmittedWikiPage.Id, existingWikiPage.WikiPage.Id);
        await _wikiPageRepository.DeleteAsync(existingWikiPage.WikiPage.Id);
        return Ok(new { Message = "WikiPage updated successfully" });
    }
    
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpDelete("admin/{id:guid}")]
    public async Task<IActionResult> DeleteWikiPageForAdmin(Guid id)
    {
        var result = await _wikiPageRepository.DeleteAsync(id);

        if (!result)
        {
            return NotFound(new { Message = "WikiPage doesn't exist" });
        }

        return Ok(new { Message = "WikiPage deleted successfully" });
    }
    
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpDelete("AdminDecline/{id:guid}")]
    public async Task<IActionResult> DeleteUserSubmittedWikiPage(Guid id)
    {
        var result =  await _wikiPageRepository.DeleteUserSubmittedAsync(id, null);
        if (!result)
        {
            return NotFound(new { Message = "WikiPage doesn't exist" });
        }
        return Ok(new { Message = "UserSubmittedWikiPage deleted successfully" });
    }
    
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpGet("GetSubmittedPageTitles")]
    public async Task<ActionResult<IEnumerable<Tuple<string, int>>>> GetSubmittedPages()
    {
        var titles = await _wikiPageRepository.GetSubmittedPageTitlesAndIdAsync();

        return Ok(titles);
    }
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpGet("GetSubmittedPageById/{id:guid}")]
    public async Task<ActionResult<UserSubmittedWikiPage>> GetSubmittedPageById(Guid id)
    {
        var wikiPage = await _wikiPageRepository.GetSubmittedPageByIdAsync(id);
        
        if (wikiPage == null)
        {
            return NotFound(); // Return 404 if the page is not found
        }

        //For some reason the returned object has the Id of zero, need to look into it further

        return Ok(wikiPage);
    }
    
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpGet("GetSubmittedUpdates")]
    public async Task<ActionResult<IEnumerable<string>>> GetSubmittedUpdates()
    {
        var titles = await _wikiPageRepository.GetSubmittedUpdateTitlesAndIdAsync();

        return Ok(titles);
    }
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpGet("GetSubmittedUpdateById/{id:guid}")]
    public async Task<ActionResult<UserSubmittedWikiPage>> GetSubmittedUpdateByTitle(Guid id)
    {
        var wikiPage = await _wikiPageRepository.GetSubmittedUpdateByIdAsync(id);
        
        if (wikiPage == null)
        {
            return NotFound(); // Return 404 if the page is not found
        }
        //No idea why, but without the line below the Id will be 0

        return Ok(wikiPage);
    }
}