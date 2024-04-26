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
    
    public WikiPagesController(IWikiPageRepository wikiPageRepository)
    {
        _wikiPageRepository = wikiPageRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<WikiPage>>> GetWikiPages()
    {
        var wikiPages = await _wikiPageRepository.GetAllAsync();
        return Ok(wikiPages);
    }
    
    [HttpGet("GetTitles")]
    public async Task<ActionResult<IEnumerable<string>>> GetWikiPageTitles()
    {
        var wikiPageTitles = await _wikiPageRepository.GetAllTitlesAsync();
        return Ok(wikiPageTitles);
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
            Category = wikiPageWithImagesInputModel.Category
        };
        var images = wikiPageWithImagesInputModel.Images;
        
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
            Category = wikiPageWithImagesInputModel.Category,
            SubmittedBy = wikiPageWithImagesInputModel.SubmittedBy,
            PostDate = DateTime.Now
        };
        
        var images = wikiPageWithImagesInputModel.Images;
        
        await _wikiPageRepository.AddUserSubmittedPageAsync(newWikiPage, images);

        return CreatedAtAction(nameof(GetWikiPage), new { id = newWikiPage.Id }, newWikiPage);
    }
    
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpPost("AdminAccept")]
    public async Task<ActionResult<WikiPage>> AcceptCreatedPageForUser([FromBody] string id)
    {
        var guid = Guid.Parse(id);
        Console.WriteLine($"id is: {guid}");
        var userSubmittedWikiPage = await _wikiPageRepository.GetSubmittedPageByIdAsync(guid);

        if (userSubmittedWikiPage is { UserSubmittedWikiPage: null })
        {
            return NotFound(); // Return 404 if the user-submitted page is not found
        }

        // Update the Approved property to true
        Console.WriteLine(userSubmittedWikiPage.UserSubmittedWikiPage);
        userSubmittedWikiPage.UserSubmittedWikiPage.Approved = true;

        // Save the changes to the database
        await _wikiPageRepository.AcceptUserSubmittedWikiPage(userSubmittedWikiPage.UserSubmittedWikiPage);

        return Ok(new { Message = "UserSubmittedWikiPage approved successfully" });
    }
    
    
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpPut("admin/{id:guid}")]
    public async Task<IActionResult> UpdateWikiPageForAdmin(Guid id, [FromForm] WikiPageWithImagesInputModel wikiPageWithImagesInputModel)
    {
        Console.WriteLine(wikiPageWithImagesInputModel);
        var existingWikiPageOutputModel = await _wikiPageRepository.GetByIdAsync(id);

        if (existingWikiPageOutputModel == null)
            return NotFound();
        
        var updatedWikiPage = new WikiPage
        {
            Title = wikiPageWithImagesInputModel.Title,
            SiteSub = wikiPageWithImagesInputModel.SiteSub,
            RoleNote = wikiPageWithImagesInputModel.RoleNote,
            Content = wikiPageWithImagesInputModel.Content,
            Paragraphs = wikiPageWithImagesInputModel.Paragraphs,
            Category = wikiPageWithImagesInputModel.Category,
            LegacyWikiPage = wikiPageWithImagesInputModel.LegacyWikiPage
        };
        var images = wikiPageWithImagesInputModel.Images;
        await _wikiPageRepository.UpdateAsync(existingWikiPageOutputModel.WikiPage, updatedWikiPage, images);

        return Ok(new { Message = "WikiPage updated successfully" });
    }
    
    //This method returns 400 for some reason, will need to check later
    [Authorize(Policy = IdentityData.UserPolicyName)]
    [HttpPut("user/{id:guid}")]
    public async Task<IActionResult> UpdateWikiPageForUser(Guid id, [FromBody] UserSubmittedWikiPage updatedWikiPage)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            return BadRequest(errors);
        }
        updatedWikiPage.Id = Guid.NewGuid();
        updatedWikiPage.PostDate = DateTime.Now;
        // Console.WriteLine(updatedWikiPage);
        // if (updatedWikiPage.WikiPage == null)
        // {
        //     return BadRequest("Wikipage is missing from the updatedWikipage");
        // }
        await _wikiPageRepository.UserSubmittedUpdateAsync(updatedWikiPage);

        return CreatedAtAction(nameof(GetWikiPage), new { id = updatedWikiPage.Id }, updatedWikiPage);
    }
    
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpPatch("AdminAccept/{id:guid}")]
    public async Task<IActionResult> AcceptUpdateWikiPageForUser(Guid id, [FromBody] UserSubmittedWikiPage userSubmittedWikiPage)
    {
        // WikiPage updatedWikiPage = userSubmittedWikiPage;
        var existingWikiPage = await _wikiPageRepository.GetByIdAsync(id);
        
        if (existingWikiPage == null)
            return NotFound();
        existingWikiPage.WikiPage.LastUpdateDate = DateTime.Now;
        await _wikiPageRepository.AcceptUserSubmittedUpdateAsync(existingWikiPage.WikiPage, userSubmittedWikiPage);
        await _wikiPageRepository.DeleteUserSubmittedAsync(userSubmittedWikiPage.Id, existingWikiPage.WikiPage.Id);

        return Ok(new { Message = "WikiPage updated successfully" });
    }
    
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpDelete("admin/{id:guid}")]
    public async Task<IActionResult> DeleteWikiPageForAdmin(Guid id)
    {
        await _wikiPageRepository.DeleteAsync(id);

        return Ok(new { Message = "WikiPage deleted successfully" });
    }
    
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpDelete("AdminDecline/{id:guid}")]
    public async Task<IActionResult> DeleteUserSubmittedWikiPage(Guid id)
    {
        await _wikiPageRepository.DeleteUserSubmittedAsync(id, null);

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
        Console.WriteLine(id);
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