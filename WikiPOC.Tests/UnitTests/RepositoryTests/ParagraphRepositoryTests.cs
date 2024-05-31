using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.Models;
using NUnit.Framework;
using Moq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using wiki_backend.DatabaseServices;

namespace UnitTests.RepositoryTests;
[TestFixture]

public class ParagraphRepositoryTests
{
    private ParagraphRepository _paragraphRepository;
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
        // _wikiDbContext.Database.EnsureDeleted();
        _paragraphRepository = new ParagraphRepository(_wikiDbContext);
    }
    
    [TearDown]
    public void TearDown()
    {
        // Dispose the context to release the in-memory database
        _wikiDbContext.Database.EnsureDeleted();
        _wikiDbContext.Dispose();
    }
    
    [Test]
    public async Task GetByIdAsync_ShouldReturnParagraph()
    {
        // Arrange
        var testId = Guid.NewGuid();
        var testData = new Paragraph { Id = testId, Title = "Test Paragraph" };

        // Add the test data to the in-memory database
        _wikiDbContext.Paragraphs.Add(testData);
        await _wikiDbContext.SaveChangesAsync();

        var repository = new ParagraphRepository(_wikiDbContext);

        // Act
        var result = await repository.GetByIdAsync(testId);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(testData.Id, result.Id);
        Assert.AreEqual(testData.Title, result.Title);
    }

    [Test]
    public async Task CreateAsync_ShouldReturnCreatedParagraph()
    {
        // Arrange
        var articleId = Guid.NewGuid();
        var testWikiPage = new WikiPage
        {
            Id = articleId,
            Title = "To be used for testing",
            RoleNote = "RoleNote",
            SiteSub = "SiteSub",
        };
        
        _wikiDbContext.WikiPages.Add(testWikiPage);
        await _wikiDbContext.SaveChangesAsync();
        var testData = new Paragraph { Title = "New Paragraph", WikiPageId = articleId};
    
        // Act
        await _paragraphRepository.CreateAsync(testData);
        await _wikiDbContext.SaveChangesAsync();
    
        // Assert
        CollectionAssert.Contains(_wikiDbContext.Paragraphs.ToList(), testData);
    }
    
    [Test]
    public async Task CreateAsync_ShouldReturnNullWhenWikiPageNotFound()
    {
        // Arrange
        var testData = new Paragraph { Title = "New Paragraph", WikiPageId = Guid.NewGuid() };

        // Act & Assert
        Assert.ThrowsAsync<InvalidOperationException>(async () => await _paragraphRepository.CreateAsync(testData));
    }

    [Test]
    public async Task DeleteAsync_ShouldNotThrowException()
    {
        // Arrange
        var testWikiPage = new WikiPage
        {
            Id = Guid.NewGuid(),
            Title = "To be deleted",
            RoleNote = "RoleNote",
            SiteSub = "SiteSub",
        };

        var testParagraph = new Paragraph
        {
            Id = Guid.NewGuid(),
            Title = "Paragraph to be deleted",
            WikiPageId = testWikiPage.Id,
        };

        _wikiDbContext.WikiPages.Add(testWikiPage);
        _wikiDbContext.Paragraphs.Add(testParagraph);
        await _wikiDbContext.SaveChangesAsync(); // Ensure testWikiPage and testParagraph are added to the database

        // Act
        await _paragraphRepository.DeleteAsync(testParagraph.Id);
        await _wikiDbContext.SaveChangesAsync();

        // Assert
        var deletedParagraph = await _wikiDbContext.Paragraphs.FindAsync(testParagraph.Id);
        Assert.IsNull(deletedParagraph);
        var updatedWikiPage = await _wikiDbContext.WikiPages.Include(wp => wp.Paragraphs).FirstOrDefaultAsync(w => w.Id == testWikiPage.Id);
        Assert.IsNotNull(updatedWikiPage);
        CollectionAssert.DoesNotContain(updatedWikiPage.Paragraphs, testParagraph);
       
    }
}