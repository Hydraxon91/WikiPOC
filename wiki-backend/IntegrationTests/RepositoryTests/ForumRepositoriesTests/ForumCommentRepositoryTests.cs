using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using wiki_backend.DatabaseServices.Repositories.ForumRepositories;
using wiki_backend.Models;
using wiki_backend.Models.ForumModels;

namespace IntegrationTests.ForumRepositoriesTests;

[TestFixture]
public class ForumCommentRepositoryTests : IntegrationTestBase
{
    private ForumCommentRepository _repository;

        [SetUp]
        public void SetUp()
        {
            ResetDatabase(); // Ensure a clean database for each test
            _repository = new ForumCommentRepository(DbContext);
        }

        [Test]
        public async Task GetByIdAsync_ShouldReturnComment()
        {
            // Arrange
            await AddSampleForumPostsToDatabase();
            var forumPost = await DbContext.ForumPosts.FirstOrDefaultAsync();
            var userProfile = await DbContext.UserProfiles.FirstOrDefaultAsync();
            var comment = new ForumComment
            {
                Content = "Test comment",
                UserProfileId = userProfile.Id,
                ForumPostId = forumPost.Id,
                PostDate = DateTime.UtcNow
            };
            DbContext.ForumComments.Add(comment);
            await DbContext.SaveChangesAsync();

            // Act
            var result = await _repository.GetByIdAsync(comment.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(comment.Content, result.Content);
            Assert.AreEqual(comment.UserProfileId, result.UserProfileId);
            Assert.AreEqual(comment.ForumPostId, result.ForumPostId);
        }
        
        [Test]
        public async Task GetByIdAsync_ShouldReturnNull_WhenCommentDoesNotExist()
        {
            // Act
            var result = await _repository.GetByIdAsync(Guid.NewGuid());

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task AddAsync_ShouldAddComment()
        {
            // Arrange
            await AddSampleForumPostsToDatabase();
            var forumPost = await DbContext.ForumPosts.FirstOrDefaultAsync();
            var userProfile = await DbContext.UserProfiles.FirstOrDefaultAsync();
            var comment = new ForumComment
            {
                Content = "Test comment",
                UserProfileId = userProfile.Id,
                ForumPostId = forumPost.Id,
                PostDate = DateTime.UtcNow
            };

            // Act
            await _repository.AddAsync(comment);

            // Assert
            var addedComment = await DbContext.ForumComments.FirstOrDefaultAsync(c => c.Content == "Test comment");
            Assert.IsNotNull(addedComment);
            Assert.AreEqual(comment.Content, addedComment.Content);
        }
        
        [Test]
        public async Task AddAsync_ShouldThrowException_WhenCommentContentIsNull()
        {
            // Arrange
            await AddSampleForumPostsToDatabase();
            var forumPost = await DbContext.ForumPosts.FirstOrDefaultAsync();
            var userProfile = await DbContext.UserProfiles.FirstOrDefaultAsync();
            var comment = new ForumComment
            {
                Content = null, // Setting content to null
                UserProfileId = userProfile.Id,
                ForumPostId = forumPost.Id,
                PostDate = DateTime.UtcNow
            };

            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _repository.AddAsync(comment));
        }

        [Test]
        public async Task UpdateAsync_ShouldUpdateComment()
        {
            // Arrange
            await AddSampleForumPostsToDatabase();
            var forumPost = await DbContext.ForumPosts.FirstOrDefaultAsync();
            var userProfile = await DbContext.UserProfiles.FirstOrDefaultAsync();
            var comment = new ForumComment
            {
                Content = "Test comment",
                UserProfileId = userProfile.Id,
                ForumPostId = forumPost.Id,
                PostDate = DateTime.UtcNow
            };
            DbContext.ForumComments.Add(comment);
            await DbContext.SaveChangesAsync();

            // Act
            await _repository.UpdateAsync(comment.Id, "Updated comment");

            // Assert
            var updatedComment = await DbContext.ForumComments.FirstOrDefaultAsync(c => c.Id == comment.Id);
            Assert.IsNotNull(updatedComment);
            Assert.AreEqual("Updated comment", updatedComment.Content);
        }
        
        [Test]
        public async Task UpdateAsync_ShouldThrowException_WhenCommentIdDoesNotExist()
        {
            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _repository.UpdateAsync(Guid.NewGuid(), "Updated comment"));
        }

        [Test]
        public async Task DeleteAsync_ShouldDeleteComment()
        {
            // Arrange
            await AddSampleForumPostsToDatabase();
            var forumPost = await DbContext.ForumPosts.FirstOrDefaultAsync();
            var userProfile = await DbContext.UserProfiles.FirstOrDefaultAsync();
            var comment = new ForumComment
            {
                Content = "Test comment",
                UserProfileId = userProfile.Id,
                ForumPostId = forumPost.Id,
                PostDate = DateTime.UtcNow
            };
            DbContext.ForumComments.Add(comment);
            await DbContext.SaveChangesAsync();

            // Act
            await _repository.DeleteAsync(comment.Id);

            // Assert
            var deletedComment = await DbContext.ForumComments.FindAsync(comment.Id);
            Assert.IsNull(deletedComment);
        }
        
        [Test]
        public async Task DeleteAsync_ShouldNotDeleteComment_WhenCommentIdDoesNotExist()
        {
            // Act
            await _repository.DeleteAsync(Guid.NewGuid());

            // Assert
            var totalComments = await DbContext.ForumComments.CountAsync();
            Assert.AreEqual(0, totalComments);
        }
        
        private async Task AddSampleForumPostsToDatabase()
        {
            DbContext.ForumPosts.RemoveRange(await DbContext.ForumPosts.ToListAsync());
            DbContext.ForumTopics.RemoveRange(await DbContext.ForumTopics.ToListAsync());
            DbContext.UserProfiles.RemoveRange(await DbContext.UserProfiles.ToListAsync());
            // Add sample ForumTopic object to the database
            var forumTopic = new ForumTopic
            {
                Title = "Test Topic",
                Description = "Test Description",
                Slug = "test-topic"
            };
            await DbContext.ForumTopics.AddAsync(forumTopic);
            await DbContext.SaveChangesAsync();

            // Add sample UserProfile objects to the database
            var userProfiles = new List<UserProfile>
            {
                new UserProfile
                {
                    UserName = "User1"  
                },
                new UserProfile
                {
                    UserName = "User2"  
                },
                new UserProfile
                {
                    UserName = "User3"  
                }
            };
            await DbContext.UserProfiles.AddRangeAsync(userProfiles);
            await DbContext.SaveChangesAsync();
            // Add sample ForumPost objects to the database
            var posts = new List<ForumPost>
            {
                new ForumPost { PostTitle = "Post 1", Content = "Content for Post 1", Slug = "post-1", UserId = userProfiles[0].Id, UserName = userProfiles[0].UserName, ForumTopicId = forumTopic.Id },
                new ForumPost { PostTitle = "Post 2", Content = "Content for Post 2", Slug = "post-2", UserId = userProfiles[1].Id, UserName = userProfiles[1].UserName, ForumTopicId = forumTopic.Id },
                new ForumPost { PostTitle = "Post 3", Content = "Content for Post 3", Slug = "post-3", UserId = userProfiles[2].Id, UserName = userProfiles[2].UserName, ForumTopicId = forumTopic.Id }
            };
            await DbContext.ForumPosts.AddRangeAsync(posts);
            await DbContext.SaveChangesAsync();
        }
}