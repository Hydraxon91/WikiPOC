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

            Assert.That(postInDb, Is.Not.Null);
            Assert.That(postInDb.PostTitle, Is.EqualTo("Test Post"));
            Assert.That(postInDb.Slug, Is.EqualTo("test-post"));
        }

        [Test]
        public async Task GetAllForumPostTitlesAsync_ShouldReturnAllTitles()
        {
            var forumPost1 = new ForumPost { Id = Guid.NewGuid(), PostTitle = "Post 1", Content = "Content 1", ForumTopicId = Guid.NewGuid(), UserId = Guid.NewGuid(), UserName = "User1" };
            var forumPost2 = new ForumPost { Id = Guid.NewGuid(), PostTitle = "Post 2", Content = "Content 2", ForumTopicId = Guid.NewGuid(), UserId = Guid.NewGuid(), UserName = "User2" };

            await _forumPostRepository.AddForumPostAsync(forumPost1);
            await _forumPostRepository.AddForumPostAsync(forumPost2);

            var titles = await _forumPostRepository.GetAllForumPostTitlesAsync();

            Assert.That(titles.Count(), Is.EqualTo(2));
            Assert.That(titles.ToList(), Does.Contain("Post 1"));
            Assert.That(titles.ToList(), Does.Contain("Post 2"));
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

            Assert.That(postInDb, Is.Not.Null);
            Assert.That(postInDb.PostTitle, Is.EqualTo("Unique Post"));
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
                UserId = userProfile.Id,
                UserName = "SlugUser"
            };

            // Adding the forum post
            await _forumPostRepository.AddForumPostAsync(forumPost);

            // Fetching the post by slug
            var postInDb = await _forumPostRepository.GetForumPostBySlugAsync("unique-slug-post");

            // Assertions
            Assert.That(postInDb, Is.Not.Null);
            Assert.That(postInDb.PostTitle, Is.EqualTo("Unique Slug Post"));
            Assert.That(postInDb.Content, Is.EqualTo("Content for slug post"));
            Assert.That(postInDb.UserId, Is.EqualTo(userProfile.Id));
            Assert.That(postInDb.UserName, Is.EqualTo("SlugUser"));
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

            await _forumPostRepository.UpdateForumPostAsync(forumPost, forumPost);

            var postInDb = await _wikiDbContext.ForumPosts.FirstOrDefaultAsync(p => p.Id == forumPost.Id);

            Assert.That(postInDb, Is.Not.Null);
            Assert.That(postInDb.PostTitle, Is.EqualTo("Updated Post"));
            Assert.That(postInDb.Slug, Is.EqualTo("updated-post"));
        }

        [Test]
        public async Task DeleteForumPostAsync_ShouldDeleteForumPost()
        {
            var forumPostId = Guid.NewGuid();
            var userId = Guid.NewGuid();

            var forumPost = new ForumPost
            {
                Id = forumPostId,
                PostTitle = "Post to Delete",
                Content = "Content to Delete",
                ForumTopicId = Guid.NewGuid(),
                UserId = userId,
                UserName = "DeleteUser"
            };

            var forumComment = new ForumComment
            {
                Id = Guid.NewGuid(),
                Content = "Comment to Delete",
                UserProfileId = userId,
                ForumPostId = forumPostId
            };

            await _forumPostRepository.AddForumPostAsync(forumPost);
            await _wikiDbContext.ForumComments.AddAsync(forumComment);
            await _wikiDbContext.SaveChangesAsync();

            await _forumPostRepository.DeleteForumPostAsync(forumPostId);

            var postInDb = await _wikiDbContext.ForumPosts.FirstOrDefaultAsync(p => p.Id == forumPostId);
            var commentInDb = await _wikiDbContext.ForumComments.FirstOrDefaultAsync(c => c.ForumPostId == forumPostId);

            Assert.That(postInDb, Is.Null);
            Assert.That(commentInDb, Is.Null);
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
            Assert.That(allPosts.Count, Is.EqualTo(2));

            // Fetching posts by slug
            var postInDb1 = await _forumPostRepository.GetForumPostBySlugAsync("duplicate-title");
            var postInDb2 = await _forumPostRepository.GetForumPostBySlugAsync("duplicate-title-1");

            // Assertions
            Assert.That(postInDb1, Is.Not.Null);
            Assert.That(postInDb1.PostTitle, Is.EqualTo("Duplicate Title"));
            Assert.That(postInDb1.Content, Is.EqualTo("Content 1"));

            Assert.That(postInDb2, Is.Not.Null);
            Assert.That(postInDb2.PostTitle, Is.EqualTo("Duplicate Title"));
            Assert.That(postInDb2.Content, Is.EqualTo("Content 2"));
        }
    }
}
