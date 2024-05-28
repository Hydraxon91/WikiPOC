using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using wiki_backend.DatabaseServices;
using wiki_backend.DatabaseServices.Repositories.ForumRepositories;
using wiki_backend.Models;
using wiki_backend.Models.ForumModels;

namespace UnitTests.RepositoryTests
{
    [TestFixture]
    public class ForumPostRepositoryTests
    {
        private ForumPostRepository _forumPostRepository;
        private WikiDbContext _wikiDbContext;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<WikiDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _wikiDbContext = new WikiDbContext(options, configuration: null);
            _wikiDbContext.Database.EnsureCreated();
            _forumPostRepository = new ForumPostRepository(_wikiDbContext);
        }

        [TearDown]
        public void TearDown()
        {
            _wikiDbContext.Database.EnsureDeleted();
            _wikiDbContext.Dispose();
        }

        [Test]
        public async Task AddForumPostAsync_ShouldAddForumPost()
        {
            var forumPost = new ForumPost
            {
                Id = Guid.NewGuid(),
                PostTitle = "Test Post",
                Content = "Test Content",
                ForumTopicId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                UserName = "TestUser"
            };

            await _forumPostRepository.AddForumPostAsync(forumPost);

            var postInDb = await _wikiDbContext.ForumPosts.FirstOrDefaultAsync(p => p.Id == forumPost.Id);

            Assert.NotNull(postInDb);
            Assert.AreEqual("Test Post", postInDb.PostTitle);
            Assert.AreEqual("test-post", postInDb.Slug);
        }

        [Test]
        public async Task GetAllForumPostTitlesAsync_ShouldReturnAllTitles()
        {
            var forumPost1 = new ForumPost { Id = Guid.NewGuid(), PostTitle = "Post 1", Content = "Content 1", ForumTopicId = Guid.NewGuid(), UserId = Guid.NewGuid(), UserName = "User1" };
            var forumPost2 = new ForumPost { Id = Guid.NewGuid(), PostTitle = "Post 2", Content = "Content 2", ForumTopicId = Guid.NewGuid(), UserId = Guid.NewGuid(), UserName = "User2" };

            await _forumPostRepository.AddForumPostAsync(forumPost1);
            await _forumPostRepository.AddForumPostAsync(forumPost2);

            var titles = await _forumPostRepository.GetAllForumPostTitlesAsync();

            Assert.AreEqual(2, titles.Count());
            Assert.Contains("Post 1", titles.ToList());
            Assert.Contains("Post 2", titles.ToList());
        }

        [Test]
        public async Task GetForumPostByIdAsync_ShouldReturnCorrectPost()
        {
            var forumPost = new ForumPost
            {
                Id = Guid.NewGuid(),
                PostTitle = "Unique Post",
                Content = "Unique Content",
                ForumTopicId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                UserName = "UniqueUser"
            };

            await _forumPostRepository.AddForumPostAsync(forumPost);

            var postInDb = await _forumPostRepository.GetForumPostByIdAsync(forumPost.Id);

            Assert.NotNull(postInDb);
            Assert.AreEqual("Unique Post", postInDb.PostTitle);
        }

        [Test]
        public async Task GetForumPostBySlugAsync_ShouldReturnCorrectPost()
        {
            // Seeding UserProfile entities
            var userProfile = new UserProfile { Id = Guid.NewGuid(), UserName = "SlugUser" };
            await _wikiDbContext.UserProfiles.AddAsync(userProfile);
            await _wikiDbContext.SaveChangesAsync();

            // Creating ForumPost entity
            var forumPost = new ForumPost
            {
                Id = Guid.NewGuid(),
                PostTitle = "Unique Slug Post",
                Content = "Content for slug post",
                ForumTopicId = Guid.NewGuid(),
                UserId = userProfile.Id,  // Reference the seeded user profile
                UserName = "SlugUser"
            };

            // Adding the forum post
            await _forumPostRepository.AddForumPostAsync(forumPost);

            // Fetching the post by slug
            var postInDb = await _forumPostRepository.GetForumPostBySlugAsync("unique-slug-post");

            // Additional logging for debugging
            Console.WriteLine("Database contents during query:");
            var debugPosts = await _wikiDbContext.ForumPosts
                .Include(post => post.Comments)
                .ThenInclude(comment => comment.UserProfile)
                .Include(post => post.User)
                .ToListAsync();
            foreach (var post in debugPosts)
            {
                Console.WriteLine($"ID: {post.Id}, Title: {post.PostTitle}, Slug: {post.Slug}, Content: {post.Content}, UserId: {post.UserId}, UserName: {post.UserName}");
                foreach (var comment in post.Comments)
                {
                    Console.WriteLine($"-- Comment ID: {comment.Id}, UserProfileId: {comment.UserProfileId}");
                }
            }

            // Assertions
            Assert.NotNull(postInDb);
            Assert.AreEqual("Unique Slug Post", postInDb.PostTitle);
            Assert.AreEqual("Content for slug post", postInDb.Content);
            Assert.AreEqual(userProfile.Id, postInDb.UserId);  // Verify the user ID
            Assert.AreEqual("SlugUser", postInDb.UserName);    // Verify the user name
        }


        [Test]
        public async Task UpdateForumPostAsync_ShouldUpdateForumPost()
        {
            var forumPost = new ForumPost
            {
                Id = Guid.NewGuid(),
                PostTitle = "Original Post",
                Content = "Original Content",
                ForumTopicId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                UserName = "OriginalUser"
            };

            await _forumPostRepository.AddForumPostAsync(forumPost);

            forumPost.PostTitle = "Updated Post";
            forumPost.Content = "Updated Content";

            await _forumPostRepository.UpdateForumPostAsync(forumPost);

            var postInDb = await _wikiDbContext.ForumPosts.FirstOrDefaultAsync(p => p.Id == forumPost.Id);

            Assert.NotNull(postInDb);
            Assert.AreEqual("Updated Post", postInDb.PostTitle);
            Assert.AreEqual("updated-post", postInDb.Slug);
        }

        [Test]
        public async Task DeleteForumPostAsync_ShouldDeleteForumPost()
        {
            var forumPost = new ForumPost
            {
                Id = Guid.NewGuid(),
                PostTitle = "Post to Delete",
                Content = "Content to Delete",
                ForumTopicId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                UserName = "DeleteUser"
            };

            await _forumPostRepository.AddForumPostAsync(forumPost);

            await _forumPostRepository.DeleteForumPostAsync(forumPost.Id);

            var postInDb = await _wikiDbContext.ForumPosts.FirstOrDefaultAsync(p => p.Id == forumPost.Id);

            Assert.Null(postInDb);
        }

        [Test]
        public async Task GenerateSlug_ShouldCreateUniqueSlug()
        {
            // Seeding UserProfile entities
            var userProfile1 = new UserProfile { Id = Guid.NewGuid(), UserName = "User1" };
            var userProfile2 = new UserProfile { Id = Guid.NewGuid(), UserName = "User2" };

            await _wikiDbContext.UserProfiles.AddRangeAsync(userProfile1, userProfile2);
            await _wikiDbContext.SaveChangesAsync();

            // Creating ForumPost entities
            var forumPost1 = new ForumPost
            {
                Id = Guid.NewGuid(),
                PostTitle = "Duplicate Title",
                Content = "Content 1",
                ForumTopicId = Guid.NewGuid(),
                UserId = userProfile1.Id,
                UserName = "User1"
            };
            var forumPost2 = new ForumPost
            {
                Id = Guid.NewGuid(),
                PostTitle = "Duplicate Title",
                Content = "Content 2",
                ForumTopicId = Guid.NewGuid(),
                UserId = userProfile2.Id,
                UserName = "User2"
            };

            // Adding the first post
            await _forumPostRepository.AddForumPostAsync(forumPost1);

            // Adding the second post
            await _forumPostRepository.AddForumPostAsync(forumPost2);

            // Verify both posts were added
            var allPosts = await _wikiDbContext.ForumPosts.ToListAsync();
            Assert.AreEqual(2, allPosts.Count);

            // Fetching posts by slug
            var postInDb1 = await _forumPostRepository.GetForumPostBySlugAsync("duplicate-title");
            var postInDb2 = await _forumPostRepository.GetForumPostBySlugAsync("duplicate-title-1");

            // Additional logging for debugging
            Console.WriteLine("Database contents during query:");
            var debugPosts = await _wikiDbContext.ForumPosts
                .Include(post => post.Comments)
                    .ThenInclude(comment => comment.UserProfile)
                .Include(post => post.User)
                .ToListAsync();
            foreach (var post in debugPosts)
            {
                Console.WriteLine($"ID: {post.Id}, Title: {post.PostTitle}, Slug: {post.Slug}, Content: {post.Content}, UserId: {post.UserId}");
                foreach (var comment in post.Comments)
                {
                    Console.WriteLine($"-- Comment ID: {comment.Id}, UserProfileId: {comment.UserProfileId}");
                }
            }

            // Assertions
            Assert.NotNull(postInDb1);
            Assert.AreEqual("Duplicate Title", postInDb1.PostTitle);
            Assert.AreEqual("Content 1", postInDb1.Content);

            Assert.NotNull(postInDb2);
            Assert.AreEqual("Duplicate Title", postInDb2.PostTitle);
            Assert.AreEqual("Content 2", postInDb2.Content);
        }
    }
}
