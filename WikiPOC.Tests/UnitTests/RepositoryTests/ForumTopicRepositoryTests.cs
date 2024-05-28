using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using wiki_backend.DatabaseServices;
using wiki_backend.DatabaseServices.Repositories.ForumRepositories;
using wiki_backend.Models.ForumModels;

namespace UnitTests.RepositoryTests
{
    [TestFixture]
    public class ForumTopicRepositoryTests
    {
        private ForumTopicRepository _forumTopicRepository;
        private WikiDbContext _wikiDbContext;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<WikiDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _wikiDbContext = new WikiDbContext(options, configuration: null);
            _wikiDbContext.Database.EnsureCreated();
            _wikiDbContext.Database.EnsureDeleted();
            _forumTopicRepository = new ForumTopicRepository(_wikiDbContext);
        }

        [TearDown]
        public void TearDown()
        {
            _wikiDbContext.Database.EnsureDeleted();
            _wikiDbContext.Dispose();
        }

        [Test]
        public async Task AddForumTopicAsync_ShouldAddForumTopic()
        {
            var forumTopic = new ForumTopic
            {
                Id = Guid.NewGuid(),
                Title = "Test Topic",
                Description = "Test Description"
            };

            await _forumTopicRepository.AddForumTopicAsync(forumTopic);

            var topicInDb = await _wikiDbContext.ForumTopics.FirstOrDefaultAsync(t => t.Id == forumTopic.Id);

            Assert.NotNull(topicInDb);
            Assert.AreEqual("Test Topic", topicInDb.Title);
            Assert.AreEqual("test-topic", topicInDb.Slug);
            Assert.AreEqual(1, topicInDb.Order);
        }

        [Test]
        public async Task GetAllForumTopicsAsync_ShouldReturnAllForumTopics()
        {
            var forumTopic1 = new ForumTopic { Id = Guid.NewGuid(), Title = "Topic 1", Description = "Test Description" };
            var forumTopic2 = new ForumTopic { Id = Guid.NewGuid(), Title = "Topic 2", Description = "Test Description" };

            await _forumTopicRepository.AddForumTopicAsync(forumTopic1);
            await _forumTopicRepository.AddForumTopicAsync(forumTopic2);

            var topics = await _forumTopicRepository.GetAllForumTopicsAsync();

            Assert.AreEqual(2, topics.Count());
            Assert.AreEqual("Topic 1", topics.First().Title);
            Assert.AreEqual("Topic 2", topics.Last().Title);
        }

        [Test]
        public async Task GetForumTopicBySlugAsync_ShouldReturnCorrectTopic()
        {
            var forumTopic = new ForumTopic
            {
                Id = Guid.NewGuid(),
                Title = "Unique Topic",
                Description = "Test Description"
            };

            await _forumTopicRepository.AddForumTopicAsync(forumTopic);

            var topicInDb = await _forumTopicRepository.GetForumTopicBySlugAsync("unique-topic");

            Assert.NotNull(topicInDb);
            Assert.AreEqual("Unique Topic", topicInDb.Title);
        }

        [Test]
        public async Task UpdateForumTopicAsync_ShouldUpdateForumTopic()
        {
            var forumTopic = new ForumTopic
            {
                Id = Guid.NewGuid(),
                Title = "Original Title",
                Description = "Test Description"
            };

            await _forumTopicRepository.AddForumTopicAsync(forumTopic);

            forumTopic.Title = "Updated Title";

            await _forumTopicRepository.UpdateForumTopicAsync(forumTopic);

            var topicInDb = await _wikiDbContext.ForumTopics.FirstOrDefaultAsync(t => t.Id == forumTopic.Id);

            Assert.NotNull(topicInDb);
            Assert.AreEqual("Updated Title", topicInDb.Title);
            Assert.AreEqual("updated-title", topicInDb.Slug);
        }

        [Test]
        public async Task DeleteForumTopicAsync_ShouldDeleteForumTopic()
        {
            var forumTopic = new ForumTopic
            {
                Id = Guid.NewGuid(),
                Title = "Topic to Delete",
                Description = "Test Description"
            };

            await _forumTopicRepository.AddForumTopicAsync(forumTopic);

            await _forumTopicRepository.DeleteForumTopicAsync(forumTopic.Id);

            var topicInDb = await _wikiDbContext.ForumTopics.FirstOrDefaultAsync(t => t.Id == forumTopic.Id);

            Assert.Null(topicInDb);
        }

        [Test]
        public async Task GenerateSlug_ShouldCreateUniqueSlug()
        {
            var forumTopic1 = new ForumTopic { Id = Guid.NewGuid(), Title = "Duplicate Title" ,Description = "Test Description"};
            var forumTopic2 = new ForumTopic { Id = Guid.NewGuid(), Title = "Duplicate Title", Description = "Test Description" };

            await _forumTopicRepository.AddForumTopicAsync(forumTopic1);
            await _forumTopicRepository.AddForumTopicAsync(forumTopic2);

            var topics = await _forumTopicRepository.GetAllForumTopicsAsync();

            Assert.AreEqual(2, topics.Count());
            Assert.AreEqual("duplicate-title", topics.First().Slug);
            Assert.AreEqual("duplicate-title-1", topics.Last().Slug);
        }
    }
}
