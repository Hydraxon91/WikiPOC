using wiki_backend.DatabaseServices.Repositories;
using wiki_backend.Models;
using NUnit.Framework;
using Moq;
using System.Threading.Tasks;

namespace UnitTests.RepositoryTests;
[TestFixture]
public class ParagraphRepositoryTests
{
    [Test]
    public async Task GetByIdAsync_ShouldReturnParagraph()
    {
        // Arrange
        var testData = new Paragraph { Id = 1, Title = "Test Paragraph" };
        var mockRepository = new Mock<IParagraphRepository>();
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
    public async Task CreateAsync_ShouldReturnCreatedParagraph()
    {
        // Arrange
        var testData = new Paragraph { Id = 2, Title = "New Paragraph" };
        var mockRepository = new Mock<IParagraphRepository>();
        mockRepository.Setup(repo => repo.CreateAsync(It.IsAny<Paragraph>())).ReturnsAsync(testData);

        // Act
        var result = await mockRepository.Object.CreateAsync(new Paragraph());

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(testData.Id, result.Id);
        Assert.AreEqual(testData.Title, result.Title);
        // Additional assertions based on your test data and expectations
    }

    [Test]
    public async Task DeleteAsync_ShouldNotThrowException()
    {
        // Arrange
        var mockRepository = new Mock<IParagraphRepository>();
        mockRepository.Setup(repo => repo.DeleteAsync(It.IsAny<int>())).Returns(Task.CompletedTask);

        // Act and Assert
        Assert.DoesNotThrowAsync(async () => await mockRepository.Object.DeleteAsync(1));
    }
}