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
        var testData = new List<WikiPage> { new WikiPage { Id = 1, Title = "Page 1" }, new WikiPage { Id = 2, Title = "Page 2" } };
        var mockRepository = new Mock<IWikiPageRepository>();
        mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(testData);

        // Act
        var result = await mockRepository.Object.GetAllAsync();

        // Assert
        Assert.IsNotNull(result);
        CollectionAssert.AreEqual(testData, result);
        // Additional assertions based on your test data and expectations
    }

    [Test]
    public async Task GetByIdAsync_ShouldReturnWikiPageById()
    {
        // Arrange
        var testData = new WikiPage { Id = 1, Title = "Test Page" };
        var mockRepository = new Mock<IWikiPageRepository>();
        mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(testData);

        // Act
        var result = await mockRepository.Object.GetByIdAsync(1);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(testData.Id, result.Id);
        Assert.AreEqual(testData.Title, result.Title);
        // Additional assertions based on your test data and expectations
    }
    
    [Test]
    public async Task GetAllTitlesAsync_ShouldReturnAllWikiPageTitles()
    {
        // Arrange
        var testData = new List<WikiPage>
        {
            new WikiPage { Id = 1, Title = "Page 1" },
            new WikiPage { Id = 2, Title = "Page 2" },
            new WikiPage { Id = 3, Title = "Page 3" }
        };
            
        var expectedTitles = testData.Select(page => page.Title);
            
        var mockRepository = new Mock<IWikiPageRepository>();
        mockRepository.Setup(repo => repo.GetAllTitlesAsync()).ReturnsAsync(expectedTitles);

        // Act
        var result = await mockRepository.Object.GetAllTitlesAsync();

        // Assert
        Assert.IsNotNull(result);
        CollectionAssert.AreEqual(expectedTitles, result);
        // Additional assertions based on your test data and expectations
    }
    
    [Test]
    public async Task GetByTitleAsync_ShouldReturnWikiPageForValidTitle()
    {
        // Arrange
        var expectedTitle = "Page 1";
        var expectedWikiPage = new WikiPage { Id = 1, Title = expectedTitle };

        var mockRepository = new Mock<IWikiPageRepository>();
        mockRepository.Setup(repo => repo.GetByTitleAsync(expectedTitle)).ReturnsAsync(expectedWikiPage);

        // Act
        var result = await mockRepository.Object.GetByTitleAsync(expectedTitle);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(expectedWikiPage, result);
        // Additional assertions based on your test data and expectations
    }

    [Test]
    public async Task GetByTitleAsync_ShouldReturnNullForInvalidTitle()
    {
        // Arrange
        var invalidTitle = "Nonexistent Page";
            
        var mockRepository = new Mock<IWikiPageRepository>();
        mockRepository.Setup(repo => repo.GetByTitleAsync(invalidTitle)).ReturnsAsync(null as WikiPage);

        // Act
        var result = await mockRepository.Object.GetByTitleAsync(invalidTitle);

        // Assert
        Assert.IsNull(result);
        // Additional assertions based on your test data and expectations
    }
    
    [Test]
    public async Task AddAsync_ShouldAddWikiPageWithAssociatedParagraphs()
    {
        // Arrange
        var wikiPageToAdd = new WikiPage
        {
            Id = 10,
            Title = "Example WikiPage",
            RoleNote = "Example RoleNote",
            SiteSub = "Example SiteSub",
            Paragraphs = new List<Paragraph>
            {
                new Paragraph
                {
                    Id = 10,
                    Title = "Paragraph 1",
                    Content = "Content 1",
                },
                new Paragraph
                {
                    Id = 11,
                    Title = "Paragraph 2",
                    Content = "Content 2",
                }
            }
        };

        // Act
        await _wikiPageRepository.AddAsync(wikiPageToAdd);
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
        // Arrange
        var userSubmittedWikiPageToAdd = new UserSubmittedWikiPage
        {
            Id = 1,
            Title = "New Page",
            RoleNote = "Example RoleNote",
            SiteSub = "Example SiteSub",
            SubmittedBy = "Tester",
            IsNewPage = true,
            Paragraphs = new List<Paragraph>
            {
                new Paragraph {Id = 11, Title = "Paragraph 1", Content = "Content 1" },
                new Paragraph {Id = 12, Title = "Paragraph 2", Content = "Content 2" },
            }
        };

        // Act
        await _wikiPageRepository.AddUserSubmittedPageAsync(userSubmittedWikiPageToAdd);
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
    
    [Test]
    public async Task UpdateAsync_ShouldUpdateWikiPageAndParagraphs()
    {
        // Arrange
        var existingWikiPage = new WikiPage
        {
            Id = 1,
            Title = "Existing Page",
            RoleNote = "Existing RoleNote",
            SiteSub = "Existing SiteSub",
            Paragraphs = new List<Paragraph>
            {
                new Paragraph { Id = 1, Title = "Existing Paragraph 1", Content = "Existing Content 1" },
                new Paragraph { Id = 2, Title = "Existing Paragraph 2", Content = "Existing Content 2" }
            }
        };
        
        await _wikiPageRepository.AddAsync(existingWikiPage);
        // Add a check to verify the data is in the database
        var wikiPageInDb = await _wikiDbContext.WikiPages.FirstOrDefaultAsync(wp => wp.Id == existingWikiPage.Id);
        Assert.NotNull(wikiPageInDb);
        
        
        var updatedWikiPage = new WikiPage
        {
            Id = 1,
            Title = "Updated Page",
            RoleNote = "Updated RoleNote",
            SiteSub = "Updated SiteSub",
            Paragraphs = new List<Paragraph>
            {
                new Paragraph { Id = 1, Title = "Updated Paragraph 1", Content = "Updated Content 1" },
                new Paragraph { Id = 3, Title = "New Paragraph 3", Content = "New Content 3" }
            }
        };

        // Act
        await _wikiPageRepository.UpdateAsync(wikiPageInDb, updatedWikiPage);
        await _wikiDbContext.SaveChangesAsync(); // Save changes to the in-memory database

        // Assert
        // Verify WikiPage is updated
        var updatedWikiPageInDb = _wikiDbContext.WikiPages.FirstOrDefault(wp => wp.Id == existingWikiPage.Id);
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
public async Task AcceptUserSubmittedUpdateAsync_ShouldUpdateWikiPageAndParagraphs()
{
    // Arrange
    var existingWikiPage = new WikiPage
    {
        Id = 1,
        Title = "Existing Page",
        RoleNote = "Existing RoleNote",
        SiteSub = "Existing SiteSub",
        Paragraphs = new List<Paragraph>
        {
            new Paragraph { Id = 1, Title = "Existing Paragraph 1", Content = "Existing Content 1" },
            new Paragraph { Id = 2, Title = "Existing Paragraph 2", Content = "Existing Content 2" }
        }
    };

    await _wikiPageRepository.AddAsync(existingWikiPage);

    var updatedWikiPage = new WikiPage
    {
        Id = 1,
        Title = "Updated Page",
        RoleNote = "Updated RoleNote",
        SiteSub = "Updated SiteSub",
        Paragraphs = new List<Paragraph>
        {
            new Paragraph { Id = 1, Title = "Updated Paragraph 1", Content = "Updated Content 1" },
            new Paragraph { Id = 3, Title = "New Paragraph 3", Content = "New Content 3" }
        }
    };

    // Act
    await _wikiPageRepository.AcceptUserSubmittedUpdateAsync(existingWikiPage, updatedWikiPage);
    await _wikiDbContext.SaveChangesAsync(); // Save changes to the in-memory database

    // Assert
    // Verify WikiPage is updated
    var updatedWikiPageInDb = _wikiDbContext.WikiPages.FirstOrDefault(wp => wp.Id == existingWikiPage.Id);
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
}