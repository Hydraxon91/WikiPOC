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

            _wikiDbContext = new WikiDbContext(options, configuration: null!);
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

            Assert.That(topicInDb, Is.Not.Null);
            Assert.That(topicInDb.Title, Is.EqualTo("Test Topic"));
            Assert.That(topicInDb.Slug, Is.EqualTo("test-topic"));
            Assert.That(topicInDb.Order, Is.EqualTo(1));
        }

        [Test]
        public async Task GetAllForumTopicsAsync_ShouldReturnAllForumTopics()
        {
            var forumTopic1 = new ForumTopic { Id = Guid.NewGuid(), Title = "Topic 1", Description = "Test Description" };
            var forumTopic2 = new ForumTopic { Id = Guid.NewGuid(), Title = "Topic 2", Description = "Test Description" };

            await _forumTopicRepository.AddForumTopicAsync(forumTopic1);
            await _forumTopicRepository.AddForumTopicAsync(forumTopic2);

            var topics = await _forumTopicRepository.GetAllForumTopicsAsync();

            Assert.That(topics.Count(), Is.EqualTo(2));
            Assert.That(topics.First().Title, Is.EqualTo("Topic 1"));
            Assert.That(topics.Last().Title, Is.EqualTo("Topic 2"));
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

            Assert.That(topicInDb, Is.Not.Null);
            Assert.That(topicInDb.Title, Is.EqualTo("Unique Topic"));
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

            Assert.That(topicInDb, Is.Not.Null);
            Assert.That(topicInDb.Title, Is.EqualTo("Updated Title"));
            Assert.That(topicInDb.Slug, Is.EqualTo("updated-title"));
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

            Assert.That(topicInDb, Is.Null);
        }

        [Test]
        public async Task GenerateSlug_ShouldCreateUniqueSlug()
        {
            var forumTopic1 = new ForumTopic { Id = Guid.NewGuid(), Title = "Duplicate Title", Description = "Test Description" };
            var forumTopic2 = new ForumTopic { Id = Guid.NewGuid(), Title = "Duplicate Title", Description = "Test Description" };

            await _forumTopicRepository.AddForumTopicAsync(forumTopic1);
            await _forumTopicRepository.AddForumTopicAsync(forumTopic2);

            var topics = await _forumTopicRepository.GetAllForumTopicsAsync();

            Assert.That(topics.Count(), Is.EqualTo(2));
            Assert.That(topics.First().Slug, Is.EqualTo("duplicate-title"));
            Assert.That(topics.Last().Slug, Is.EqualTo("duplicate-title-1"));
        }
    }
}
