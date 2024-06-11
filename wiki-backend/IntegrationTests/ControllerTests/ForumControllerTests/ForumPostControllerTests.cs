using DotNetEnv;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using wiki_backend.Controllers.ForumControllers;
using wiki_backend.DatabaseServices.Repositories.ForumRepositories;
using wiki_backend.Models;
using wiki_backend.Models.ForumModels;

namespace IntegrationTests.ControllerTests.ForumControllerTests;

[TestFixture]
[NonParallelizable]
public class ForumPostControllerTests : IntegrationTestBase
{
        private ForumPostController _controller;
        private IForumPostRepository _forumPostRepository;
        private UserManager<ApplicationUser> _userManager;
        private string? _token;
        private string? _userName;
        private string? _email;

        [SetUp]
        public async Task SetUp()
        {
            // Check JWT configuration, This shouldn't fix anything but somehow it did?
            Env.TraversePath().Load();
            var signingKey = Environment.GetEnvironmentVariable("JWT_ISSUER_SIGNING_KEY");
            
            _forumPostRepository = new ForumPostRepository(DbContext);
            _userManager = ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            _controller = new ForumPostController(_forumPostRepository, _userManager);
            ResetDatabase();
            await EnsureUserRoleExistsAsync();
            _userName = $"{GetRandomizedString("testuser")}";
            _email = $"{GetRandomizedString("test")}@example.com";
            await CreateAdminUserAsync(_email, _userName, "@Password123");
            _token = await GetValidUserToken(_email, _userName, "@Password123");
        }

        [Test]
        public async Task GetForumPostTitles_ShouldReturnTitles()
        {
            // Arrange
            var userProfileId = await AddUserProfile();
            await AddForumTopicAndPost(userProfileId);

            // Act
            var result = await _controller.GetForumPostTitles();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            var titles = okResult.Value as IEnumerable<string>;

            Assert.IsNotNull(titles);
            Assert.Contains("test", titles.ToList());
        }

        [Test]
        public async Task GetForumPostBySlug_ShouldReturnPost()
        {
            // Arrange
            var userProfileId = await AddUserProfile();
            var forumPostId = await AddForumTopicAndPost(userProfileId);

            var forumPost = await DbContext.ForumPosts.FindAsync(forumPostId);

            // Act
            var result = await _controller.GetForumPostBySlug(forumPost.Slug);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            var returnedPost = okResult.Value as ForumPost;

            Assert.IsNotNull(returnedPost);
            Assert.AreEqual(forumPost.Slug, returnedPost.Slug);
        }

        [Test]
        public async Task AddForumPost_ShouldAddPost()
        {
            // Arrange
            _controller.ControllerContext.HttpContext = new DefaultHttpContext
            {
                Request = { Headers = { ["Authorization"] = $"Bearer {_token}" } }
            };

            var userProfileId = await AddUserProfile();
            var forumTopicId = await AddForumTopic(userProfileId);

            var forumPostForm = new ForumPostForm
            {
                PostTitle = "New Post",
                Content = "This is a new post",
                PostDate = DateTime.UtcNow,
                ForumTopicId = forumTopicId.ToString(),
                UserId = userProfileId.ToString(),
                UserName = _userName
            };

            // Act
            var result = await _controller.AddForumPost(forumPostForm);

            // Assert
            Assert.IsInstanceOf<CreatedAtActionResult>(result.Result);
            var createdResult = result.Result as CreatedAtActionResult;
            var createdPost = createdResult.Value as ForumPost;

            Assert.IsNotNull(createdPost);
            Assert.AreEqual(forumPostForm.PostTitle, createdPost.PostTitle);
        }

        [Test]
        public async Task UpdateForumPost_ShouldUpdatePost()
        {
            // Arrange
            _controller.ControllerContext.HttpContext = new DefaultHttpContext
            {
                Request = { Headers = { ["Authorization"] = $"Bearer {_token}" } }
            };

            var userProfileId = await AddUserProfile();
            var forumPostId = await AddForumTopicAndPost(userProfileId);

            var post = await DbContext.ForumPosts.Include(post => post.Comments).FirstOrDefaultAsync(fp => fp.Id == forumPostId);

            var updatedPost = new ForumPost
            {
                Id = post.Id,
                PostTitle = "Updated Post",
                Content = "This is an updated post",
                PostDate = post.PostDate,
                ForumTopicId = post.ForumTopicId,
                UserId = post.UserId,
                UserName = post.UserName,
                Slug = post.Slug
            };

            // Act
            var result = await _controller.UpdateForumPost(post.Id, updatedPost);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var updatedPostInDb = await DbContext.ForumPosts.FindAsync(post.Id);
            Assert.AreEqual("Updated Post", updatedPostInDb.PostTitle);
        }

        [Test]
        public async Task DeleteForumPost_ShouldDeletePost()
        {
            // Arrange
            _controller.ControllerContext.HttpContext = new DefaultHttpContext
            {
                Request = { Headers = { ["Authorization"] = $"Bearer {_token}" } }
            };

            var userProfileId = await AddUserProfile();
            var forumPostId = await AddForumTopicAndPost(userProfileId);

            // Act
            var result = await _controller.DeleteForumPost(forumPostId);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var deletedPostInDb = await DbContext.ForumPosts.FindAsync(forumPostId);
            Assert.IsNull(deletedPostInDb);
        }

        private async Task<Guid> AddUserProfile()
        {
            var userProfileId = Guid.NewGuid();
            var userProfile = new UserProfile
            {
                Id = userProfileId,
                UserName = _userName
            };
            await DbContext.UserProfiles.AddAsync(userProfile);
            await DbContext.SaveChangesAsync();

            return userProfileId;
        }

        private async Task<Guid> AddForumTopic(Guid userProfileId)
        {
            var forumTopicId = Guid.NewGuid();
            var forumTopic = new ForumTopic
            {
                Id = forumTopicId,
                Title = "Test",
                Description = "test",
                Slug = "test"
            };
            await DbContext.ForumTopics.AddAsync(forumTopic);
            await DbContext.SaveChangesAsync();

            return forumTopicId;
        }

        private async Task<Guid> AddForumTopicAndPost(Guid userProfileId)
        {
            var forumTopicId = await AddForumTopic(userProfileId);

            var forumPostId = Guid.NewGuid();
            var forumPost = new ForumPost
            {
                Id = forumPostId,
                UserId = userProfileId,
                Content = "test",
                PostTitle = "test",
                Slug = "test",
                UserName = _userName,
                ForumTopicId = forumTopicId,
            };
            await DbContext.ForumPosts.AddAsync(forumPost);
            await DbContext.SaveChangesAsync();

            return forumPostId;
        }
}