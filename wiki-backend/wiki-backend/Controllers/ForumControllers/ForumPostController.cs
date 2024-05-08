using Microsoft.AspNetCore.Mvc;
using wiki_backend.DatabaseServices.Repositories.ForumRepositories;

namespace wiki_backend.Controllers.ForumControllers;

[Route("api/[controller]")]
[ApiController]
public class ForumPostController : ControllerBase
{
    private readonly IForumPostRepository _forumPostRepository;

    public ForumPostController(IForumPostRepository forumPostRepository)
    {
        _forumPostRepository = forumPostRepository;
    }
    
    
}