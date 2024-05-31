using System.Text;
using IntegrationTests.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.Models;

namespace IntegrationTests.Repositories
{
    [TestFixture]
    public class StyleRepositoryTests : IntegrationTestBase
    {
        private StyleRepository _repository;

        [SetUp]
        public void SetUp()
        {
            ResetDatabase();
            _repository = new StyleRepository(DbContext);
        }

        [Test]
        public async Task GetStylesAsync_ShouldReturnStyles()
        {
            // Arrange
            var existingStyles = new StyleModel
            {
                Logo = "logo/logo_pfp.png",
                WikiName = "Your Wiki",
                BodyColor = "#507ced",
                ArticleRightColor = "#3c5fb8",
                ArticleRightInnerColor = "#2b4ea6",
                ArticleColor = "#526cad",
                FooterListLinkTextColor = "#1d305e",
                FooterListTextColor = "#233a71",
                FontFamily = "Arial, sans-serif",
            };
            DbContext.Styles.RemoveRange(await DbContext.Styles.ToListAsync());
            DbContext.Styles.Add(existingStyles);
            await DbContext.SaveChangesAsync();

            // Act
            var result = await _repository.GetStylesAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(existingStyles.ArticleColor, result.ArticleColor);
            Assert.AreEqual(existingStyles.BodyColor, result.BodyColor);
            // Add more assertions for other properties
        }

        [Test]
        public async Task UpdateStylesAsync_ShouldUpdateStyles()
        {
            // Arrange
            var existingStyles = new StyleModel
            {
                Logo = "logo/logo_pfp.png",
                WikiName = "Your Wiki",
                BodyColor = "#507ced",
                ArticleRightColor = "#3c5fb8",
                ArticleRightInnerColor = "#2b4ea6",
                ArticleColor = "#526cad",
                FooterListLinkTextColor = "#1d305e",
                FooterListTextColor = "#233a71",
                FontFamily = "Arial, sans-serif",
            };
            
            // DbContext.Styles.RemoveRange(await DbContext.Styles.ToListAsync());
            await DbContext.SaveChangesAsync();

            var updatedStyles = new StyleModel
            {
                Logo = "logo/logo_pfp.png",
                WikiName = "Your Wiki",
                BodyColor = "#527ced",
                ArticleRightColor = "#3c5fb8",
                ArticleRightInnerColor = "#2b4ea6",
                ArticleColor = "#546cad",
                FooterListLinkTextColor = "#1d305e",
                FooterListTextColor = "#233a71",
                FontFamily = "Arial, sans-serif",
            };

            // Act
            await _repository.UpdateStylesAsync(updatedStyles, null);

            // Detach existingStyles from the context
            // DbContext.Entry(existingStyles).State = EntityState.Detached;
            
            // Assert
            var result = await DbContext.Styles.FirstOrDefaultAsync();
            Assert.IsNotNull(result);
            Assert.AreEqual(updatedStyles.ArticleColor, result.ArticleColor);
            Assert.AreEqual(updatedStyles.BodyColor, result.BodyColor);
        }
        
    }
}
