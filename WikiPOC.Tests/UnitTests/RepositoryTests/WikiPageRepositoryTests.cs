using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using wiki_backend.DatabaseServices;
using wiki_backend.Models;
using wiki_backend.DatabaseServices.Repositories;

namespace UnitTests.RepositoryTests;
[TestFixture]
public class WikiPageRepositoryTests
{
    private WikiPageRepository _wikiPageRepository;
    private WikiDbContext _wikiDbContext;

    [SetUp]
    public void Setup()
    {
        Environment.SetEnvironmentVariable("PICTURES_PATH_CONTAINER", "your_picture_path_here");
        // Generate a unique database name based on the test name
        var databaseName = $"TestDatabase_{TestContext.CurrentContext.Test.Name}";
        // Use an in-memory database for testing
        var options = new DbContextOptionsBuilder<WikiDbContext>()
            .UseInMemoryDatabase(databaseName: databaseName)
            .Options;

        // Use AddDbContext to configure the WikiDbContext
        _wikiDbContext = new WikiDbContext(options, configuration: null); 
        _wikiDbContext.Database.EnsureCreated(); // Ensure the in-memory database is created
        _wikiDbContext.Database.EnsureDeleted();
        _wikiPageRepository = new WikiPageRepository(_wikiDbContext);
    }
    
    [TearDown]
    public void TearDown()
    {
        // Dispose the context to release the in-memory database
        _wikiDbContext.Database.EnsureDeleted();
        _wikiDbContext.Dispose();
    }
    
    [Test]
    public async Task GetAllAsync_ShouldReturnAllWikiPages()
    {
        // Arrange
        var articleId1 = Guid.NewGuid();
        var articleId2 = Guid.NewGuid();
        var testData = new List<WikiPage> { new WikiPage { Id = articleId1, Title = "Page 1" , RoleNote = "Test", SiteSub = "Test"}, new WikiPage { Id = articleId2, Title = "Page 2" , RoleNote = "Test", SiteSub = "Test"} };
        
        // Add the test data to the in-memory database
        _wikiDbContext.WikiPages.AddRange(testData);
        await _wikiDbContext.SaveChangesAsync();

        // Act
        var result = await _wikiPageRepository.GetAllAsync();

        // Assert
        Assert.IsNotNull(result);
        CollectionAssert.AreEqual(testData, result);
    }

    [Test]
    public async Task GetByIdAsync_ShouldReturnWikiPageById()
    {
        // Add a dummy category to the in-memory database
        var dummyCategory = new Category
        {
            Id = Guid.NewGuid(),
            CategoryName = "Dummy Category"
        };
        _wikiDbContext.Categories.Add(dummyCategory);
        await _wikiDbContext.SaveChangesAsync();
        // Arrange
        var articleId1 = Guid.NewGuid();
        var testData = new WikiPage { Id = articleId1, Title = "Test Page" , RoleNote = "Test", SiteSub = "Test", CategoryId = dummyCategory.Id};
        // Add the test data to the in-memory database
        _wikiDbContext.WikiPages.Add(testData);
        await _wikiDbContext.SaveChangesAsync();

        var repository = new WikiPageRepository(_wikiDbContext);

        // Act
        var result = await repository.GetByIdAsync(articleId1);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(testData.Id, result.WikiPage.Id);
        Assert.AreEqual(testData.Title, result.WikiPage.Title);
        Assert.AreEqual(testData.RoleNote, result.WikiPage.RoleNote);
        Assert.AreEqual(testData.SiteSub, result.WikiPage.SiteSub);
    }
    
    [Test]
    public async Task GetAllTitlesAsync_ShouldReturnAllWikiPageTitles()
    {
        // Add a dummy category to the in-memory database
        var dummyCategory = new Category
        {
            Id = Guid.NewGuid(),
            CategoryName = "Dummy Category"
        };
        _wikiDbContext.Categories.Add(dummyCategory);
        await _wikiDbContext.SaveChangesAsync();
        // Arrange
        var articleId1 = Guid.NewGuid();
        var articleId2 = Guid.NewGuid();
        var articleId3 = Guid.NewGuid();
        var testData = new List<WikiPage>
        {
            new WikiPage { Id = articleId1, Title = "Page 1" , RoleNote = "Test", SiteSub = "Test", CategoryId = dummyCategory.Id},
            new WikiPage { Id = articleId2, Title = "Page 2" , RoleNote = "Test", SiteSub = "Test", CategoryId = dummyCategory.Id},
            new WikiPage { Id = articleId3, Title = "Page 3" , RoleNote = "Test", SiteSub = "Test", CategoryId = dummyCategory.Id}
        };
        
        _wikiDbContext.WikiPages.AddRange(testData);
        await _wikiDbContext.SaveChangesAsync();

        // Act
        var result = await _wikiPageRepository.GetAllTitlesAndCategoriesAsync();

        // Assert
        Assert.IsNotNull(result);
        CollectionAssert.AreEqual(testData.Select(page => page.Title), result.Select(r=> r.Title));
    }
    
    [Test]
    public async Task GetByTitleAsync_ShouldReturnWikiPageForValidTitle()
    {
        // Add a dummy category to the in-memory database
        var dummyCategory = new Category
        {
            Id = Guid.NewGuid(),
            CategoryName = "Dummy Category"
        };
        _wikiDbContext.Categories.Add(dummyCategory);
        await _wikiDbContext.SaveChangesAsync();
        
        // Arrange
        var articleId1 = Guid.NewGuid();
        var expectedTitle = "Page 1";
        var expectedWikiPage = new WikiPage { Id = articleId1, Title = expectedTitle, RoleNote = "Test", SiteSub = "Test", CategoryId = dummyCategory.Id};

        // Add the test data to the in-memory database
        _wikiDbContext.WikiPages.Add(expectedWikiPage);
        await _wikiDbContext.SaveChangesAsync();

        var repository = new WikiPageRepository(_wikiDbContext);

        // Act
        var result = await repository.GetByTitleAsync(expectedTitle);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(expectedWikiPage.Id, result.WikiPage.Id);
        Assert.AreEqual(expectedWikiPage.Title, result.WikiPage.Title);
    }

    [Test]
    public async Task GetByTitleAsync_ShouldReturnNullForInvalidTitle()
    {
        // Arrange
        var invalidTitle = "Nonexistent Page";
            
        var mockRepository = new Mock<IWikiPageRepository>();
        mockRepository.Setup(repo => repo.GetByTitleAsync(invalidTitle)).ReturnsAsync(null as WPWithImagesOutputModel);

        // Act
        var result = await mockRepository.Object.GetByTitleAsync(invalidTitle);

        // Assert
        Assert.IsNull(result);
        // Additional assertions based on your test data and expectations
    }
    
    [Test]
    public async Task AddAsync_ShouldAddWikiPageWithAssociatedParagraphs()
    {
        // Add a dummy category to the in-memory database
        var dummyCategory = new Category
        {
            Id = Guid.NewGuid(),
            CategoryName = "Dummy Category"
        };
        _wikiDbContext.Categories.Add(dummyCategory);
        await _wikiDbContext.SaveChangesAsync();
        
        // Arrange
        var articleId1 = Guid.NewGuid();
        var articleId2 = Guid.NewGuid();
        var articleId3 = Guid.NewGuid();
        var wikiPageToAdd = new WikiPage
        {
            Id = articleId1,
            Title = "Example WikiPage",
            RoleNote = "Example RoleNote",
            SiteSub = "Example SiteSub",
            Paragraphs = new List<Paragraph>
            {
                new Paragraph
                {
                    Id = articleId2,
                    Title = "Paragraph 1",
                    Content = "Content 1",
                },
                new Paragraph
                {
                    Id = articleId3,
                    Title = "Paragraph 2",
                    Content = "Content 2",
                }
            },
            CategoryId = dummyCategory.Id
        };

        // Act
        await _wikiPageRepository.AddAsync(wikiPageToAdd, new List<ImageFormModel>());
        await _wikiDbContext.SaveChangesAsync(); // Save changes to the in-memory database

        // Assert
        // Check if the WikiPage is added to the context
        CollectionAssert.Contains(_wikiDbContext.WikiPages.ToList(), wikiPageToAdd);

        // Check if Paragraphs are added with correct associations
        var paragraphsList = await _wikiDbContext.Paragraphs.ToListAsync();
        foreach (var paragraph in wikiPageToAdd.Paragraphs)
        {
            Assert.AreEqual(wikiPageToAdd.Id, paragraph.WikiPageId);
            Assert.AreSame(wikiPageToAdd, paragraph.WikiPage);
            CollectionAssert.Contains(paragraphsList, paragraph);
        }
    }

    [Test]
    public async Task AddUserSubmittedPageAsync_ShouldAddUserSubmittedWikiPageWithAssociatedParagraphs()
    {
        // Add a dummy category to the in-memory database
        var dummyCategory = new Category
        {
            Id = Guid.NewGuid(),
            CategoryName = "Dummy Category"
        };
        _wikiDbContext.Categories.Add(dummyCategory);
        await _wikiDbContext.SaveChangesAsync();
        // Arrange
        var articleId1 = Guid.NewGuid();
        var articleId2 = Guid.NewGuid();
        var articleId3 = Guid.NewGuid();
        var userSubmittedWikiPageToAdd = new UserSubmittedWikiPage
        {
            Id = articleId1,
            Title = "New Page",
            RoleNote = "Example RoleNote",
            SiteSub = "Example SiteSub",
            SubmittedBy = "Tester",
            IsNewPage = true,
            Paragraphs = new List<Paragraph>
            {
                new Paragraph {Id = articleId2, Title = "Paragraph 1", Content = "Content 1" },
                new Paragraph {Id = articleId3, Title = "Paragraph 2", Content = "Content 2" },
            },
            CategoryId = dummyCategory.Id
        };

        // Act
        await _wikiPageRepository.AddUserSubmittedPageAsync(userSubmittedWikiPageToAdd, new List<ImageFormModel>());
        await _wikiDbContext.SaveChangesAsync(); // Save changes to the in-memory database
            
        // Log the UserSubmittedWikiPages for debugging
        var userSubmittedPages = _wikiDbContext.UserSubmittedWikiPages.ToList();
        Console.WriteLine("UserSubmittedWikiPages in database:");
        foreach (var page in userSubmittedPages)
        {
            Console.WriteLine($"Id: {page.Id}, Title: {page.Title}");
        }
            
        // Assert
        // Check if the WikiPage is added to the context
        CollectionAssert.Contains(_wikiDbContext.WikiPages.ToList(), userSubmittedWikiPageToAdd);
        // var addedWikiPage = _wikiDbContext.UserSubmittedWikiPages.FirstOrDefault(wp => wp.Id == userSubmittedWikiPageToAdd.Id);
        // Assert.NotNull(addedWikiPage);

        // Check if Paragraphs are added with correct associations
        var paragraphsList = await _wikiDbContext.Paragraphs.ToListAsync(); // Convert DbSet to List
        foreach (var paragraph in userSubmittedWikiPageToAdd.Paragraphs)
        {
            Assert.AreEqual(userSubmittedWikiPageToAdd.Id, paragraph.WikiPageId);
            Assert.AreSame(userSubmittedWikiPageToAdd, paragraph.WikiPage);

            // Use CollectionAssert.Contains for collections
            CollectionAssert.Contains(paragraphsList, paragraph);
        }
    }
    
    // [Test]
    // public async Task UpdateAsync_ShouldUpdateWikiPageAndParagraphs()
    // {
    //     // Add a dummy category to the in-memory database
    //     var dummyCategory = new Category
    //     {
    //         Id = Guid.NewGuid(),
    //         CategoryName = "Dummy Category"
    //     };
    //     _wikiDbContext.Categories.Add(dummyCategory);
    //     await _wikiDbContext.SaveChangesAsync();
    //
    //     // Arrange
    //     var articleId1 = Guid.NewGuid();
    //     var articleId2 = Guid.NewGuid();
    //     var articleId3 = Guid.NewGuid();
    //     var existingWikiPage = new WikiPage
    //     {
    //         Id = articleId1,
    //         Title = "Existing Page",
    //         RoleNote = "Existing RoleNote",
    //         SiteSub = "Existing SiteSub",
    //         Paragraphs = new List<Paragraph>
    //         {
    //             new Paragraph { Id = articleId2, Title = "Existing Paragraph 1", Content = "Existing Content 1" },
    //             new Paragraph { Id = articleId3, Title = "Existing Paragraph 2", Content = "Existing Content 2" }
    //         },
    //         CategoryId = dummyCategory.Id
    //     };
    //
    //     await _wikiPageRepository.AddAsync(existingWikiPage, new List<ImageFormModel>());
    //     
    //     // Act
    //     var updatedWikiPage = new WikiPage
    //     {
    //         Id = existingWikiPage.Id, // Retain the original ID
    //         Title = "Updated Page",
    //         RoleNote = "Updated RoleNote",
    //         SiteSub = "Updated SiteSub",
    //         Paragraphs = new List<Paragraph>
    //         {
    //             new Paragraph { Id = articleId2, Title = "Updated Paragraph 1", Content = "Updated Content 1" },
    //             new Paragraph { Id = Guid.NewGuid(), Title = "New Paragraph 3", Content = "New Content 3" }
    //         },
    //         CategoryId = dummyCategory.Id
    //     };
    //     
    //     existingWikiPage = await _wikiDbContext.WikiPages.FindAsync(existingWikiPage.Id);
    //     if (existingWikiPage == null)
    //     {
    //         Console.WriteLine(existingWikiPage);
    //         // Handle the case where the WikiPage doesn't exist
    //         // (e.g., throw an exception or log an error)
    //     }
    //
    //     await _wikiPageRepository.UpdateAsync(existingWikiPage, updatedWikiPage, new List<ImageFormModel>());
    //     await _wikiDbContext.SaveChangesAsync(); // Save changes to the in-memory database
    //
    //     // Assert
    //     // Verify WikiPage is updated
    //     var updatedWikiPageInDb = await _wikiDbContext.WikiPages.FirstOrDefaultAsync(wp => wp.Id == existingWikiPage.Id);
    //     Assert.NotNull(updatedWikiPageInDb);
    //     Assert.AreEqual(updatedWikiPage.Title, updatedWikiPageInDb.Title);
    //     Assert.AreEqual(updatedWikiPage.RoleNote, updatedWikiPageInDb.RoleNote);
    //     Assert.AreEqual(updatedWikiPage.SiteSub, updatedWikiPageInDb.SiteSub);
    //
    //     // Verify Paragraphs are updated and new one is added
    //     var paragraphsInDb = await _wikiDbContext.Paragraphs.ToListAsync();
    //     foreach (var updatedParagraph in updatedWikiPage.Paragraphs)
    //     {
    //         var matchingParagraph = paragraphsInDb.FirstOrDefault(p => p.Id == updatedParagraph.Id);
    //         Assert.NotNull(matchingParagraph);
    //         Assert.AreEqual(updatedParagraph.Title, matchingParagraph.Title);
    //         Assert.AreEqual(updatedParagraph.Content, matchingParagraph.Content);
    //     }
    // }

    
[Test]
public async Task AcceptUserSubmittedUpdateAsync_ShouldUpdateWikiPageAndParagraphs()
{
    
    // Arrange
    var articleId1 = Guid.NewGuid();
    var articleId2 = Guid.NewGuid();
    var articleId3 = Guid.NewGuid();

    // Add a dummy category to the in-memory database
    var dummyCategory = new Category
    {
        Id = Guid.NewGuid(),
        CategoryName = "Dummy Category"
    };
    _wikiDbContext.Categories.Add(dummyCategory);
    await _wikiDbContext.SaveChangesAsync();

    var updatedWikiPage = new UserSubmittedWikiPage
    {
        Id = articleId1, // Ensure the ID is the same as existingWikiPage
        Title = "Updated Page",
        RoleNote = "Updated RoleNote",
        SiteSub = "Updated SiteSub",
        Paragraphs = new List<Paragraph>
        {
            new Paragraph { Id = articleId2, Title = "Updated Paragraph 1", Content = "Updated Content 1" },
            new Paragraph { Id = articleId3, Title = "New Paragraph 3", Content = "New Content 3" }
        },
        CategoryId = dummyCategory.Id,
        SubmittedBy = "Test",
    };
    await _wikiPageRepository.AddAsync(updatedWikiPage, new List<ImageFormModel>());

    // Act
    await _wikiPageRepository.AcceptUserSubmittedUpdateAsync(updatedWikiPage);
    await _wikiDbContext.SaveChangesAsync(); // Save changes to the in-memory database

    // Assert
    // Verify WikiPage is updated
    var updatedWikiPageInDb = _wikiDbContext.WikiPages.FirstOrDefault(wp => wp.Id == updatedWikiPage.Id);
    Assert.NotNull(updatedWikiPageInDb);
    Assert.AreEqual(updatedWikiPage.Title, updatedWikiPageInDb.Title);
    Assert.AreEqual(updatedWikiPage.RoleNote, updatedWikiPageInDb.RoleNote);
    Assert.AreEqual(updatedWikiPage.SiteSub, updatedWikiPageInDb.SiteSub);

    // Verify Paragraphs are updated and new one is added
    var paragraphsInDb = await _wikiDbContext.Paragraphs.ToListAsync();
    foreach (var updatedParagraph in updatedWikiPage.Paragraphs)
    {
        var matchingParagraph = paragraphsInDb.FirstOrDefault(p => p.Id == updatedParagraph.Id);
        Assert.NotNull(matchingParagraph);
        Assert.AreEqual(updatedParagraph.Title, matchingParagraph.Title);
        Assert.AreEqual(updatedParagraph.Content, matchingParagraph.Content);
    }
}

    
    [Test]
    public async Task UserSubmittedUpdateAsync_ShouldAddUserSubmittedWikiPageWithAssociatedParagraphs()
    {
        // Add a dummy category to the in-memory database
        var dummyCategory = new Category
        {
            Id = Guid.NewGuid(),
            CategoryName = "Dummy Category"
        };
        _wikiDbContext.Categories.Add(dummyCategory);
        await _wikiDbContext.SaveChangesAsync();
        // Arrange
        var articleId1 = Guid.NewGuid();
        var articleId2 = Guid.NewGuid();
        var articleId3 = Guid.NewGuid();
        var updatedWikiPage = new UserSubmittedWikiPage
        {
            Id = articleId1,
            Title = "Updated Page",
            RoleNote = "Updated RoleNote",
            SiteSub = "Updated SiteSub",
            SubmittedBy = "Tester",
            IsNewPage = true,
            Paragraphs = new List<Paragraph>
            {
                new Paragraph { Id = articleId2, Title = "Updated Paragraph 1", Content = "Updated Content 1" },
                new Paragraph { Id = articleId3, Title = "New Paragraph 2", Content = "New Content 2" }
            }
            ,CategoryId = dummyCategory.Id
        };

        // Act
        await _wikiPageRepository.UserSubmittedUpdateAsync(updatedWikiPage, new List<ImageFormModel>());
        await _wikiDbContext.SaveChangesAsync(); // Save changes to the in-memory database

        // Assert
        // Check if the UserSubmittedWikiPage is added to the context
        var addedUserSubmittedWikiPage = _wikiDbContext.UserSubmittedWikiPages.FirstOrDefault(wp => wp.Id == updatedWikiPage.Id);
        Assert.NotNull(addedUserSubmittedWikiPage);

        // Check if Paragraphs are added with correct associations
        var paragraphsList = await _wikiDbContext.Paragraphs.ToListAsync();
        foreach (var paragraph in updatedWikiPage.Paragraphs)
        {
            Assert.AreEqual(updatedWikiPage.Id, paragraph.WikiPageId);
            Assert.AreSame(updatedWikiPage, paragraph.WikiPage);
            CollectionAssert.Contains(paragraphsList, paragraph);
        }
    }
    
    [Test]
    public async Task DeleteAsync_ShouldDeleteWikiPageAndAssociatedParagraphs()
    {
        // Add a dummy category to the in-memory database
        var dummyCategory = new Category
        {
            Id = Guid.NewGuid(),
            CategoryName = "Dummy Category"
        };
        _wikiDbContext.Categories.Add(dummyCategory);
        await _wikiDbContext.SaveChangesAsync();
        // Arrange
        var articleId1 = Guid.NewGuid();
        var articleId2 = Guid.NewGuid();
        var articleId3 = Guid.NewGuid();
        var wikiPageToDelete = new WikiPage
        {
            Id = articleId1,
            Title = "To be deleted",
            RoleNote = "RoleNote",
            SiteSub = "SiteSub",
            Paragraphs = new List<Paragraph>
            {
                new Paragraph { Id = articleId2, Title = "Paragraph 1", Content = "Content 1" },
                new Paragraph { Id = articleId3, Title = "Paragraph 2", Content = "Content 2" }
            },
            CategoryId = dummyCategory.Id
        };
        await _wikiPageRepository.AddAsync(wikiPageToDelete, new List<ImageFormModel>());

        // Act
        await _wikiPageRepository.DeleteAsync(articleId1);
        await _wikiDbContext.SaveChangesAsync();

        // Assert
        var deletedWikiPage = await _wikiDbContext.WikiPages.FindAsync(wikiPageToDelete.Id);
        Assert.Null(deletedWikiPage);

        var deletedParagraphs = await _wikiDbContext.Paragraphs.Where(p => p.WikiPageId == wikiPageToDelete.Id).ToListAsync();
        CollectionAssert.IsEmpty(deletedParagraphs);
    }

    [Test]
    public async Task DeleteUserSubmittedAsync_ShouldDeleteUserSubmittedWikiPageAndAssociatedParagraphs()
    {
        // Add a dummy category to the in-memory database
        var dummyCategory = new Category
        {
            Id = Guid.NewGuid(),
            CategoryName = "Dummy Category"
        };
        _wikiDbContext.Categories.Add(dummyCategory);
        await _wikiDbContext.SaveChangesAsync();
        // Arrange
        var articleId1 = Guid.NewGuid();
        var articleId2 = Guid.NewGuid();
        var articleId3 = Guid.NewGuid();
        var userSubmittedWikiPageToDelete = new UserSubmittedWikiPage
        {
            Id = articleId1,
            Title = "To be deleted",
            RoleNote = "RoleNote",
            SiteSub = "SiteSub",
            SubmittedBy = "Tester",
            IsNewPage = true,
            Paragraphs = new List<Paragraph>
            {
                new Paragraph { Id = articleId2, Title = "Paragraph 1", Content = "Content 1" },
                new Paragraph { Id = articleId3, Title = "Paragraph 2", Content = "Content 2" }
            },
            CategoryId = dummyCategory.Id
        };
        await _wikiPageRepository.AddUserSubmittedPageAsync(userSubmittedWikiPageToDelete, new List<ImageFormModel>());

        // Act
        await _wikiPageRepository.DeleteUserSubmittedAsync(userSubmittedWikiPageToDelete.Id, Guid.NewGuid());
        await _wikiDbContext.SaveChangesAsync();

        // Assert
        var deletedUserSubmittedWikiPage = await _wikiDbContext.UserSubmittedWikiPages.FindAsync(userSubmittedWikiPageToDelete.Id);
        Assert.Null(deletedUserSubmittedWikiPage);

        var deletedParagraphs = await _wikiDbContext.Paragraphs.Where(p => p.WikiPageId == userSubmittedWikiPageToDelete.Id).ToListAsync();
        CollectionAssert.IsEmpty(deletedParagraphs);
    }
    
    [Test]
    public async Task GetSubmittedPageTitlesAndIdAsync_ShouldReturnSubmittedPageTitlesAndIds()
    {
        // Add a dummy category to the in-memory database
        var dummyCategory = new Category
        {
            Id = Guid.NewGuid(),
            CategoryName = "Dummy Category"
        };
        _wikiDbContext.Categories.Add(dummyCategory);
        await _wikiDbContext.SaveChangesAsync();
        // Arrange
        var articleId1 = Guid.NewGuid();
        var articleId2 = Guid.NewGuid();
        var articleId3 = Guid.NewGuid();
        var submittedPages = new List<UserSubmittedWikiPage>
        {
            new UserSubmittedWikiPage { Id = articleId1, Title = "Page 1", IsNewPage = true, RoleNote = "Test", SiteSub = "Test", SubmittedBy = "Test", CategoryId = dummyCategory.Id},
            new UserSubmittedWikiPage { Id = articleId2, Title = "Page 2", IsNewPage = true, RoleNote = "Test", SiteSub = "Test", SubmittedBy = "Test", CategoryId = dummyCategory.Id },
            new UserSubmittedWikiPage { Id = articleId3, Title = "Page 3", IsNewPage = false, RoleNote = "Test", SiteSub = "Test", SubmittedBy = "Test", CategoryId = dummyCategory.Id} // Should not be included
        };
        await _wikiDbContext.UserSubmittedWikiPages.AddRangeAsync(submittedPages);
        await _wikiDbContext.SaveChangesAsync();

        // Act
        var result = await _wikiPageRepository.GetSubmittedPageTitlesAndIdAsync();

        // Assert
        var expected = submittedPages.Where(page => page.IsNewPage).Select(page => new Tuple<string, Guid>(page.Title, page.Id));
        CollectionAssert.AreEquivalent(expected, result);
    }
    
    [Test]
    public async Task GetSubmittedPageByIdAsync_ShouldReturnUserSubmittedWikiPageWithParagraphs()
    {
        // Add a dummy category to the in-memory database
        var dummyCategory = new Category
        {
            Id = Guid.NewGuid(),
            CategoryName = "Dummy Category"
        };
        _wikiDbContext.Categories.Add(dummyCategory);
        await _wikiDbContext.SaveChangesAsync();
        // Arrange
        var articleId1 = Guid.NewGuid();
        var articleId2 = Guid.NewGuid();
        var articleId3 = Guid.NewGuid();
        var userSubmittedPage = new UserSubmittedWikiPage
        {
            Id = articleId1,
            Title = "Submitted Page",
            IsNewPage = true,
            RoleNote = "Test", 
            SiteSub = "Test", 
            SubmittedBy = "Test",
            Paragraphs = new List<Paragraph>
            {
                new Paragraph { Id = articleId2, Title = "Paragraph 1", Content = "Content 1" },
                new Paragraph { Id = articleId3, Title = "Paragraph 2", Content = "Content 2" }
            },
            CategoryId = dummyCategory.Id
        };
        await _wikiDbContext.UserSubmittedWikiPages.AddAsync(userSubmittedPage);
        await _wikiDbContext.SaveChangesAsync();

        // Act
        var result = await _wikiPageRepository.GetSubmittedPageByIdAsync(userSubmittedPage.Id);

        // Assert
        Assert.NotNull(result);
        Assert.AreEqual(userSubmittedPage.Id, result.UserSubmittedWikiPage.Id);
        Assert.AreEqual(userSubmittedPage.Title, result.UserSubmittedWikiPage.Title);
        CollectionAssert.AreEqual(userSubmittedPage.Paragraphs, result.UserSubmittedWikiPage.Paragraphs);
    }
    [Test]
    public async Task GetSubmittedUpdateTitlesAndIdAsync_ShouldReturnSubmittedUpdateTitlesAndIds()
    {
        // Arrange
        var articleId1 = Guid.NewGuid();
        var articleId2 = Guid.NewGuid();
        var articleId3 = Guid.NewGuid();
        var submittedUpdatePages = new List<UserSubmittedWikiPage>
        {
            new UserSubmittedWikiPage { Id = articleId1, Title = "Page 1", IsNewPage = false, RoleNote = "Test", SiteSub = "Test", SubmittedBy = "Test" },
            new UserSubmittedWikiPage { Id = articleId2, Title = "Page 2", IsNewPage = false, RoleNote = "Test", SiteSub = "Test", SubmittedBy = "Test" },
            new UserSubmittedWikiPage { Id = articleId3, Title = "Page 3", IsNewPage = true, RoleNote = "Test", SiteSub = "Test", SubmittedBy = "Test" } // Should not be included
        };
        await _wikiDbContext.UserSubmittedWikiPages.AddRangeAsync(submittedUpdatePages);
        await _wikiDbContext.SaveChangesAsync();

        // Act
        var result = await _wikiPageRepository.GetSubmittedUpdateTitlesAndIdAsync();

        // Assert
        var expected = submittedUpdatePages.Where(page => !page.IsNewPage).Select(page => new Tuple<string, Guid>(page.Title, page.Id));
        CollectionAssert.AreEquivalent(expected, result);
    }
    
    [Test]
    public async Task GetSubmittedUpdateByIdAsync_ShouldReturnUserSubmittedUpdateWikiPageWithParagraphs()
    {
        // Arrange
        var articleId1 = Guid.NewGuid();
        var articleId2 = Guid.NewGuid();
        var articleId3 = Guid.NewGuid();
        var userSubmittedUpdatePage = new UserSubmittedWikiPage
        {
            Id = articleId1,
            Title = "Submitted Update Page",
            IsNewPage = false,
            RoleNote = "Test", SiteSub = "Test", SubmittedBy = "Test",
            Paragraphs = new List<Paragraph>
            {
                new Paragraph { Id = articleId2, Title = "Paragraph 1", Content = "Content 1" },
                new Paragraph { Id = articleId3, Title = "Paragraph 2", Content = "Content 2" }
            }
        };
        await _wikiDbContext.UserSubmittedWikiPages.AddAsync(userSubmittedUpdatePage);
        await _wikiDbContext.SaveChangesAsync();

        // Act
        var result = await _wikiPageRepository.GetSubmittedUpdateByIdAsync(userSubmittedUpdatePage.Id);

        // Assert
        Assert.NotNull(result);
        Assert.AreEqual(userSubmittedUpdatePage.Id, result.UserSubmittedWikiPage.Id);
        Assert.AreEqual(userSubmittedUpdatePage.Title, result.UserSubmittedWikiPage.Title);
        CollectionAssert.AreEqual(userSubmittedUpdatePage.Paragraphs, result.UserSubmittedWikiPage.Paragraphs);
    }
    
}