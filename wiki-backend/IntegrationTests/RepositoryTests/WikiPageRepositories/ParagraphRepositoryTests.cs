using Microsoft.EntityFrameworkCore;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.Models;

namespace IntegrationTests.Repositories
{
    [TestFixture]
    public class ParagraphRepositoryTests : IntegrationTestBase
    {
        private ParagraphRepository _repository;

        [SetUp]
        public void SetUp()
        {
            ResetDatabase();
            _repository = new ParagraphRepository(DbContext);
        }

        [Test]
        public async Task GetByIdAsync_ShouldReturnParagraph_WhenParagraphExists()
        {
            // Arrange
            var category = new Category { CategoryName = "TestCategory" };
            DbContext.Categories.Add(category);
            await DbContext.SaveChangesAsync();

            var wikiPage = new WikiPage { Title = "Test Wiki Page", CategoryId = category.Id };
            DbContext.WikiPages.Add(wikiPage);
            await DbContext.SaveChangesAsync();

            var paragraph = new Paragraph { Title = "Test Paragraph", Content = "Test Content", WikiPageId = wikiPage.Id };
            DbContext.Paragraphs.Add(paragraph);
            await DbContext.SaveChangesAsync();

            // Act
            var result = await _repository.GetByIdAsync(paragraph.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(paragraph.Title, result.Title);
            Assert.AreEqual(paragraph.Content, result.Content);
        }

        [Test]
        public async Task GetByIdAsync_ShouldReturnNull_WhenParagraphDoesNotExist()
        {
            // Act
            var result = await _repository.GetByIdAsync(Guid.NewGuid());

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task CreateAsync_ShouldAddNewParagraphToWikiPage()
        {
            // Arrange
            var category = new Category { CategoryName = "TestCategory" };
            DbContext.Categories.Add(category);
            await DbContext.SaveChangesAsync();

            var wikiPage = new WikiPage { Title = "Test Wiki Page", CategoryId = category.Id };
            DbContext.WikiPages.Add(wikiPage);
            await DbContext.SaveChangesAsync();

            var paragraph = new Paragraph { Title = "New Paragraph", Content = "New Content", WikiPageId = wikiPage.Id };

            // Act
            var result = await _repository.CreateAsync(paragraph);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(paragraph.Title, result.Title);
            Assert.AreEqual(paragraph.Content, result.Content);

            var wikiPageFromDb = await DbContext.WikiPages.Include(wp => wp.Paragraphs).FirstOrDefaultAsync(wp => wp.Id == wikiPage.Id);
            Assert.IsNotNull(wikiPageFromDb);
            Assert.AreEqual(1, wikiPageFromDb.Paragraphs.Count);
            Assert.AreEqual(paragraph.Title, wikiPageFromDb.Paragraphs.First().Title);
        }

        [Test]
        public async Task CreateAsync_ShouldReturnNull_WhenWikiPageDoesNotExist()
        {
            // Arrange
            var paragraph = new Paragraph { Title = "New Paragraph", Content = "New Content", WikiPageId = Guid.NewGuid() };

            // Act
            var result = await _repository.CreateAsync(paragraph);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task DeleteAsync_ShouldRemoveParagraph()
        {
            // Arrange
            var category = new Category { CategoryName = "TestCategory" };
            DbContext.Categories.Add(category);
            await DbContext.SaveChangesAsync();

            var wikiPage = new WikiPage { Title = "Test Wiki Page", CategoryId = category.Id };
            DbContext.WikiPages.Add(wikiPage);
            await DbContext.SaveChangesAsync();

            var paragraph = new Paragraph { Title = "Test Paragraph", Content = "Test Content", WikiPageId = wikiPage.Id };
            DbContext.Paragraphs.Add(paragraph);
            await DbContext.SaveChangesAsync();

            // Act
            await _repository.DeleteAsync(paragraph.Id);

            // Assert
            var result = await _repository.GetByIdAsync(paragraph.Id);
            Assert.IsNull(result);
        }

        [Test]
        public async Task DeleteAsync_ShouldNotThrow_WhenParagraphDoesNotExist()
        {
            // Act & Assert
            Assert.DoesNotThrowAsync(async () => await _repository.DeleteAsync(Guid.NewGuid()));
        }
    }
}
