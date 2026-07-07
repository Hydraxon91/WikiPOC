using IntegrationTests.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.Models;
using wiki_backend.Services.Settings;

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
            var storageSettings = Options.Create(new StorageSettings { PicturesPath = PicturesPathContainer });
            _repository = new StyleRepository(DbContext, storageSettings);
        }

        [Test]
        public async Task GetActiveStylesAsync_ShouldReturnActiveStyle()
        {
            // Arrange
            var existingStyles = new StyleModel
            {
                IsActive = true,
                IsSystemPreset = true,
                InterfaceEra = "wikipedia",
                Logo = "logo/logo_pfp.png",
                WikiName = "Your Wiki",
                BodyColor = "#507ced",
                ArticleRightColor = "#3c5fb8",
                ArticleRightInnerColor = "#2b4ea6",
                ArticleColor = "#526cad",
                FooterListLinkTextColor = "#1d305e",
                FooterListTextColor = "#233a71",
                FontFamily = "Arial, sans-serif",
                GlassBgOpacity = 1.0,
                GlassBlurRadius = 0,
                GlassBorderReflection = 0,
                BgMeshGradient = "none",
                BorderRadius = "0px",
                BorderStyle = "1px solid #a2a9b1",
            };
            DbContext.Styles.RemoveRange(await DbContext.Styles.ToListAsync());
            DbContext.Styles.Add(existingStyles);
            await DbContext.SaveChangesAsync();

            // Act
            var result = await _repository.GetActiveStylesAsync();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.IsActive, Is.True);
            Assert.That(result.ArticleColor, Is.EqualTo(existingStyles.ArticleColor));
            Assert.That(result.BodyColor, Is.EqualTo(existingStyles.BodyColor));
        }

        [Test]
        public async Task UpdateStylesAsync_ShouldUpdateStyles()
        {
            // Arrange
            var existingStyles = new StyleModel
            {
                IsActive = true,
                InterfaceEra = "wikipedia",
                Logo = "logo/logo_pfp.png",
                WikiName = "Your Wiki",
                BodyColor = "#507ced",
                ArticleRightColor = "#3c5fb8",
                ArticleRightInnerColor = "#2b4ea6",
                ArticleColor = "#526cad",
                FooterListLinkTextColor = "#1d305e",
                FooterListTextColor = "#233a71",
                FontFamily = "Arial, sans-serif",
                GlassBgOpacity = 1.0,
                GlassBlurRadius = 0,
                GlassBorderReflection = 0,
                BgMeshGradient = "none",
                BorderRadius = "0px",
                BorderStyle = "1px solid #a2a9b1",
            };
            
            DbContext.Styles.Add(existingStyles);
            await DbContext.SaveChangesAsync();

            var updatedStyles = new StyleModel
            {
                InterfaceEra = "glass",
                Logo = "logo/logo_pfp.png",
                WikiName = "Your Wiki",
                BodyColor = "#527ced",
                ArticleRightColor = "#3c5fb8",
                ArticleRightInnerColor = "#2b4ea6",
                ArticleColor = "#546cad",
                FooterListLinkTextColor = "#1d305e",
                FooterListTextColor = "#233a71",
                FontFamily = "Arial, sans-serif",
                GlassBgOpacity = 0.5,
                GlassBlurRadius = 8,
                GlassBorderReflection = 0.1,
                BgMeshGradient = "radial-gradient(circle, #000, #fff)",
                BorderRadius = "8px",
                BorderStyle = "1px solid rgba(255,255,255,0.2)",
            };

            // Act
            await _repository.UpdateStylesAsync(updatedStyles, null);

            // Assert
            var result = await DbContext.Styles.FirstOrDefaultAsync();
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ArticleColor, Is.EqualTo(updatedStyles.ArticleColor));
            Assert.That(result.BodyColor, Is.EqualTo(updatedStyles.BodyColor));
            Assert.That(result.InterfaceEra, Is.EqualTo(updatedStyles.InterfaceEra));
            Assert.That(result.GlassBgOpacity, Is.EqualTo(updatedStyles.GlassBgOpacity));
        }

        [Test]
        public async Task ActivateThemeAsync_ShouldSwapActivation()
        {
            // Arrange
            DbContext.Styles.RemoveRange(await DbContext.Styles.ToListAsync());
            DbContext.Styles.AddRange(
                new StyleModel { InterfaceEra = "wikipedia", IsActive = true, IsSystemPreset = true },
                new StyleModel { InterfaceEra = "glass", IsActive = false, IsSystemPreset = true }
            );
            await DbContext.SaveChangesAsync();
            var glassTheme = await DbContext.Styles.FirstAsync(s => s.InterfaceEra == "glass");

            // Act
            await _repository.ActivateThemeAsync(glassTheme.Id);

            // Assert
            var wikipediaTheme = await DbContext.Styles.FirstAsync(s => s.InterfaceEra == "wikipedia");
            var glassThemeAfter = await DbContext.Styles.FirstAsync(s => s.InterfaceEra == "glass");
            Assert.That(wikipediaTheme.IsActive, Is.False);
            Assert.That(glassThemeAfter.IsActive, Is.True);
        }
    }
}
