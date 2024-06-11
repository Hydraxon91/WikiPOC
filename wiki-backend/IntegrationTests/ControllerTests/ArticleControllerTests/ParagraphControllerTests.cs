using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using wiki_backend.Controllers;
using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.Models;

namespace IntegrationTests.ControllerTests.ArticleControllerTests;

[TestFixture]
public class ParagraphControllerTests : IntegrationTestBase
{
    private ParagraphController _controller;
    private IParagraphRepository _paragraphRepository;

    [SetUp]
    public void SetUp()
    {
        _paragraphRepository = new Mock<IParagraphRepository>().Object;
        _controller = new ParagraphController(_paragraphRepository);
    }
    
    [Test]
    public async Task GetParagraph_NonExistingId_ReturnsNotFoundResult()
    {
        // Arrange
        var nonExistingId = Guid.NewGuid();

        // Act
        var result = await _controller.GetParagraph(nonExistingId) as ActionResult<Paragraph>;

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<NotFoundResult>(result.Result);
    }

    [Test]
    public async Task CreateParagraph_ValidInput_ReturnsCreatedAtActionResult()
    {
        // Arrange
        var newParagraph = new Paragraph { WikiPageId = Guid.NewGuid(), Title = "Test Title", Content = "Test Content" };

        // Act
        var result = await _controller.CreateParagraph(newParagraph) as ActionResult<Paragraph>;

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<CreatedAtActionResult>(result.Result);

        var createdAtResult = result.Result as CreatedAtActionResult;
        Assert.IsNotNull(createdAtResult);
        Assert.AreEqual(nameof(_controller.GetParagraph), createdAtResult.ActionName);

        var returnedParagraph = createdAtResult.Value as Paragraph;
        Assert.IsNotNull(returnedParagraph);
        Assert.AreEqual(newParagraph.Title, returnedParagraph.Title);
        Assert.AreEqual(newParagraph.Content, returnedParagraph.Content);
        // Assert other properties here
    }
}