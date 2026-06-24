using Microsoft.EntityFrameworkCore;
using wiki_backend.DatabaseServices.Repositories.ForumRepositories;
using wiki_backend.Models.ForumModels;

namespace IntegrationTests.ForumRepositoriesTests
{
    [TestFixture]
    public class ForumTopicRepositoryTests : IntegrationTestBase
    {
        private ForumTopicRepository _repository;

        [SetUp]
        public void SetUp()
        {
            ResetDatabase(); // Ensure a clean database for each test
            _repository = new ForumTopicRepository(DbContext);
        }

        [Test]
        public async Task GetAllForumTopicsAsync_ShouldReturnAllTopics()
        {
            // Arrange
            await AddSampleForumTopicsToDatabase();
            var expectedTopicCount = 3;

            // Act
            var result = await _repository.GetAllForumTopicsAsync();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(expectedTopicCount));
        }

        [Test]
        public async Task GetForumTopicBySlugAsync_ShouldReturnTopic()
        {
            // Arrange
            await AddSampleForumTopicsToDatabase();
            var slug = "topic-1";

            // Act
            var result = await _repository.GetForumTopicBySlugAsync(slug);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Slug, Is.EqualTo(slug));
        }

        [Test]
        public async Task AddForumTopicAsync_ShouldAddTopic()
        {
            // Arrange
            var topic = new ForumTopic
            {
                Title = "New Topic",
                Description = "Description for new Topic"
            };

            // Act
            await _repository.AddForumTopicAsync(topic);

            // Assert
            var addedTopic = await DbContext.ForumTopics.FirstOrDefaultAsync(t => t.Title == "New Topic");
            Assert.That(addedTopic, Is.Not.Null);
            Assert.That(addedTopic.Slug, Is.EqualTo("new-topic"));
            Assert.That(addedTopic.Description, Is.EqualTo(topic.Description));
        }

        [Test]
        public async Task UpdateForumTopicAsync_ShouldUpdateTopic()
        {
            // Arrange
            var existingTopic = new ForumTopic
            {
                Title = "Existing Topic",
                Description = "Existing description",
                Slug = "existing-topic"
            };
            DbContext.ForumTopics.Add(existingTopic);
            await DbContext.SaveChangesAsync();

            existingTopic.Title = "Updated Title";
            existingTopic.Description = "Updated Description";

            // Act
            await _repository.UpdateForumTopicAsync(existingTopic);

            // Assert
            var updatedTopic = await DbContext.ForumTopics.FirstOrDefaultAsync(t => t.Title == "Updated Title");
            Assert.That(updatedTopic, Is.Not.Null);
            Assert.That(updatedTopic.Slug, Is.EqualTo("updated-title")); 
            Assert.That(updatedTopic.Description, Is.EqualTo("Updated Description")); 
        }

        [Test]
        public async Task DeleteForumTopicAsync_ShouldDeleteTopic()
        {
            // Arrange
            var existingTopic = new ForumTopic
            {
                Title = "Existing Topic",
                Description = "Existing description",
                Slug = "existing-topic"
            };
            DbContext.ForumTopics.Add(existingTopic);
            await DbContext.SaveChangesAsync();

            // Act
            await _repository.DeleteForumTopicAsync(existingTopic.Id);

            // Assert
            var deletedTopic = await DbContext.ForumTopics.FindAsync(existingTopic.Id);
            Assert.That(deletedTopic, Is.Null);
        }
        
        [Test]
        public async Task AddForumTopicAsync_ShouldThrowException_WhenTitleIsNull()
        {
            // Arrange
            var topic = new ForumTopic { Description = "Description"};

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(async () => await _repository.AddForumTopicAsync(topic));
        }

        [Test]
        public async Task AddForumTopicAsync_ShouldThrowException_WhenDescriptionIsNull()
        {
            // Arrange
            var topic = new ForumTopic { Title = "Title" };

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(async () => await _repository.AddForumTopicAsync(topic));
        }


        [Test]
        public async Task AddForumTopicAsync_ShouldThrowException_WhenTitleAndDescriptionAreEmpty()
        {
            // Arrange
            var topic = new ForumTopic { Title = "", Description = "" };

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(async () => await _repository.AddForumTopicAsync(topic));
        }

        [Test]
        public async Task UpdateForumTopicAsync_ShouldThrowException_WhenTopicIsNull()
        {
            // Act & Assert
            Assert.ThrowsAsync<NullReferenceException>(async () => await _repository.UpdateForumTopicAsync(null));
        }
        
        [Test]
        public async Task AddForumTopicAsync_ShouldGenerateUniqueSlug()
        {
            // Arrange
            var existingTopic = new ForumTopic { Title = "Existing Topic", Description = "Description for Existing Topic"};
            var newTopic = new ForumTopic { Title = "Existing Topic", Description = "Description for New Topic" };

            await _repository.AddForumTopicAsync(existingTopic);

            // Act
            await _repository.AddForumTopicAsync(newTopic);

            // Assert
            var addedTopic = await DbContext.ForumTopics.FirstOrDefaultAsync(t => t.Description == "Description for New Topic");
            Assert.That(addedTopic, Is.Not.Null);
            Assert.That(addedTopic.Slug, Is.Not.EqualTo(existingTopic.Slug));
        }
        
        private async Task AddSampleForumTopicsToDatabase()
        {
            // Add sample ForumTopic objects to the database
            var topics = new List<ForumTopic>
            {
                new ForumTopic { Title = "Topic 1", Description = "Description for Topic 1", Slug = "topic-1" },
                new ForumTopic { Title = "Topic 2", Description = "Description for Topic 2", Slug = "topic-2" },
                new ForumTopic { Title = "Topic 3", Description = "Description for Topic 3", Slug = "topic-3" }
            };
            await DbContext.ForumTopics.AddRangeAsync(topics);
            await DbContext.SaveChangesAsync();
        }
    }
}
