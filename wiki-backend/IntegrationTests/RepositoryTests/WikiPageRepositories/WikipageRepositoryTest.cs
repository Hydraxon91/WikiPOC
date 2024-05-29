using Microsoft.EntityFrameworkCore;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.Models;

namespace IntegrationTests.Repositories
{
    [TestFixture]
    public class WikiPageRepositoryTests : IntegrationTestBase
    {
        private WikiPageRepository _repository;
        private CategoryRepository _categoryRepository;

        [SetUp]
        public void SetUp()
        {
            ResetDatabase();
            _repository = new WikiPageRepository(DbContext);
        }

        [Test]
        public async Task AddAsync_ShouldAddWikiPageWithImages()
        {
            // Arrange
            var category = new Category { CategoryName = "TestCategory" };
            DbContext.Categories.Add(category);
            await DbContext.SaveChangesAsync();

            var wikiPage = new WikiPage
            {
                Title = "Test Wiki Page",
                CategoryId = category.Id,
                Paragraphs = new List<Paragraph>
                {
                    new Paragraph { Title = "Paragraph 1", Content = "Content 1" }
                }
            };

            var images = new List<ImageFormModel>
            {
                new ImageFormModel { FileName = "test1.jpg", DataURL = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8/wIAAgADAQABDQgAAAAASUVORK5CYII=" },
                new ImageFormModel { FileName = "test2.jpg", DataURL = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8/wIAAgADAQABDQgAAAAASUVORK5CYII=" }
            };

            // Act
            await _repository.AddAsync(wikiPage, images);

            // Assert
            var savedWikiPage = await DbContext.WikiPages.Include(wp => wp.Paragraphs).FirstOrDefaultAsync(wp => wp.Id == wikiPage.Id);
            Assert.IsNotNull(savedWikiPage);
            Assert.AreEqual("Test Wiki Page", savedWikiPage.Title);
            Assert.AreEqual(1, savedWikiPage.Paragraphs.Count);
        }

        [Test]
        public async Task GetAllTitlesAndCategoriesAsync_ShouldReturnTitlesAndCategories()
        {
            // Arrange
            var category = new Category { CategoryName = "TestCategory" };
            var wikiPage = new WikiPage
            {
                Title = "Test Wiki Page",
                Category = category
            };
            DbContext.WikiPages.RemoveRange(await DbContext.WikiPages.ToListAsync());
            await DbContext.SaveChangesAsync();
            DbContext.WikiPages.Add(wikiPage);
            await DbContext.SaveChangesAsync();

            // Act
            var result = await _repository.GetAllTitlesAndCategoriesAsync();

            // Assert
            Assert.IsNotEmpty(result);
            Assert.AreEqual("Test Wiki Page", result.First().Title);
            Assert.AreEqual("TestCategory", result.First().Category);
        }
        
        [Test]
        public async Task GetWikiPageById_ReturnsCorrectWikiPage()
        {
            // Arrange
            var category = new Category { CategoryName = "TestCategory" };
            DbContext.Categories.Add(category);
            await DbContext.SaveChangesAsync();
            
            var wikiPage = new WikiPage
            {
                Id = Guid.NewGuid(),
                Title = "Test Wiki Page",
                CategoryId = category.Id,
            };

            DbContext.WikiPages.Add(wikiPage);
            await DbContext.SaveChangesAsync();

            // Act
            var result = await _repository.GetByIdAsync(wikiPage.Id);

            // Assert
            Assert.AreEqual(wikiPage.Title, result.WikiPage.Title);
            Assert.AreEqual(wikiPage.Id, result.WikiPage.Id);
            Assert.AreEqual(wikiPage.Category, result.WikiPage.Category);
        }
        
        [Test]
        public async Task UpdateAsync_ShouldUpdateExistingWikiPage()
        {
            // Arrange
            var category = new Category { CategoryName = "TestCategory" };
            var category2 = new Category { CategoryName = "Updated Category" };
            DbContext.Categories.Add(category);
            DbContext.Categories.Add(category2);
            await DbContext.SaveChangesAsync();
            
            var wikiPage = new WikiPage
            {
                Title = "Existing Wiki Page",
                CategoryId = category.Id
            };
            
            DbContext.WikiPages.RemoveRange(await DbContext.WikiPages.ToListAsync());
            await DbContext.SaveChangesAsync();
            DbContext.WikiPages.Add(wikiPage);
            await DbContext.SaveChangesAsync();
            
            var updatedWikiPage = new WikiPage
            {
                Id = wikiPage.Id,
                Title = "Updated Wiki Page",
                CategoryId = category2.Id
            };
            
            // Act
            await _repository.UpdateAsync(wikiPage, updatedWikiPage, new List<ImageFormModel>());
            // Assert
            var result = await DbContext.WikiPages.FindAsync(wikiPage.Id);
            Assert.IsNotNull(result);
            Assert.AreEqual(updatedWikiPage.Title, result.Title);
            Assert.AreEqual(updatedWikiPage.CategoryId, result.CategoryId);
        }
        
        [Test]
        public async Task GetAllAsync_ShouldReturnAllWikiPages()
        {
            // Arrange
            DbContext.WikiPages.RemoveRange(await DbContext.WikiPages.ToListAsync());
            await DbContext.SaveChangesAsync();
            var category = new Category { CategoryName = "TestCategory" };
            DbContext.Categories.Add(category);
            await DbContext.SaveChangesAsync();
    
            var wikiPages = new List<WikiPage>
            {
                new WikiPage { Title = "WikiPage 1", CategoryId = category.Id },
                new WikiPage { Title = "WikiPage 2", CategoryId = category.Id }
            };
            DbContext.WikiPages.AddRange(wikiPages);
            await DbContext.SaveChangesAsync();

            // Act
            var result = await _repository.GetAllAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
        }
        
        [Test]
        public async Task DeleteAsync_ShouldDeleteWikiPage()
        {
            // Arrange
            var category = new Category { CategoryName = "TestCategory" };
            DbContext.Categories.Add(category);
            await DbContext.SaveChangesAsync();
    
            var wikiPage = new WikiPage { Title = "WikiPage to Delete", CategoryId = category.Id };
            DbContext.WikiPages.Add(wikiPage);
            await DbContext.SaveChangesAsync();

            // Act
            await _repository.DeleteAsync(wikiPage.Id);

            // Assert
            var deletedWikiPage = await DbContext.WikiPages.FindAsync(wikiPage.Id);
            Assert.IsNull(deletedWikiPage);
        }
        
        [Test]
        public async Task AddUserSubmittedPageAsync_ShouldAddUserSubmittedPageWithImages()
        {
            // Arrange
            var category = new Category { CategoryName = "TestCategory" };
            DbContext.Categories.Add(category);
            await DbContext.SaveChangesAsync();

            var userSubmittedWikiPage = new UserSubmittedWikiPage
            {
                Title = "User Submitted Wiki Page",
                CategoryId = category.Id,
                Paragraphs = new List<Paragraph>
                {
                    new Paragraph { Title = "Paragraph 1", Content = "Content 1" }
                }
            };

            var images = new List<ImageFormModel>
            {
                new ImageFormModel { FileName = "test1.jpg", DataURL = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8/wIAAgADAQABDQgAAAAASUVORK5CYII=" },
                new ImageFormModel { FileName = "test2.jpg", DataURL = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8/wIAAgADAQABDQgAAAAASUVORK5CYII=" }
            };

            // Act
            await _repository.AddUserSubmittedPageAsync(userSubmittedWikiPage, images);

            // Assert
            var savedUserSubmittedPage = await DbContext.UserSubmittedWikiPages.Include(wp => wp.Paragraphs).FirstOrDefaultAsync(wp => wp.Id == userSubmittedWikiPage.Id);
            Assert.IsNotNull(savedUserSubmittedPage);
            Assert.AreEqual("User Submitted Wiki Page", savedUserSubmittedPage.Title);
            Assert.AreEqual(1, savedUserSubmittedPage.Paragraphs.Count);
        }
        
        [Test]
        public async Task AcceptUserSubmittedWikiPage_ShouldApproveUserSubmittedWikiPage()
        {
            // Arrange
            var category = new Category { CategoryName = "TestCategory" };
            DbContext.Categories.Add(category);
            await DbContext.SaveChangesAsync();

            var userSubmittedWikiPage = new UserSubmittedWikiPage
            {
                Title = "User Submitted Wiki Page",
                CategoryId = category.Id,
            };
            DbContext.UserSubmittedWikiPages.Add(userSubmittedWikiPage);
            await DbContext.SaveChangesAsync();

            // Act
            await _repository.AcceptUserSubmittedWikiPage(userSubmittedWikiPage);

            // Assert

            var approvedUserSubmittedPage = await DbContext.UserSubmittedWikiPages.FindAsync(userSubmittedWikiPage.Id);
            Assert.IsTrue(approvedUserSubmittedPage.Approved);
        }
        
        [Test]
        public async Task DeleteUserSubmittedAsync_ShouldDeleteUserSubmittedWikiPage()
        {
            // Arrange
            var category = new Category { CategoryName = "TestCategory" };
            DbContext.Categories.Add(category);
            await DbContext.SaveChangesAsync();

            var userSubmittedWikiPage = new UserSubmittedWikiPage
            {
                Title = "User Submitted Wiki Page",
                CategoryId = category.Id
            };
            DbContext.UserSubmittedWikiPages.Add(userSubmittedWikiPage);
            await DbContext.SaveChangesAsync();

            // Act
            await _repository.DeleteUserSubmittedAsync(userSubmittedWikiPage.Id, null);

            // Assert
            var deletedUserSubmittedPage = await DbContext.UserSubmittedWikiPages.FindAsync(userSubmittedWikiPage.Id);
            Assert.IsNull(deletedUserSubmittedPage);
        }
    }
}
