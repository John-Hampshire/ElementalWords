using Xunit;
using Moq;
using ElementWords.Service.Interface;
using ElementAPI.Controllers;
using ElementWords.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class ElementControllerTests
{
    [Fact]
    public async Task Get_ReturnsOkResult_WithElementWordForms()
    {
        var mockService = new Mock<IElementService>();
        var expected = new ElementWordForms { Forms = new List<List<string>> { new List<string> { "Sulfur (S)" } } };
        mockService.Setup(s => s.elementalForms("test")).ReturnsAsync(expected);

        var controller = new ElementController(mockService.Object);
        var result = await controller.Get("test");

        var okResult = Assert.IsType<OkObjectResult>(result);
        var value = Assert.IsType<ElementWordForms>(okResult.Value);
        Assert.Equal(expected.Forms, value.Forms);
    }

    [Fact]
    public async Task Get_ReturnsOkResult_WithEmptyForms_WhenServiceReturnsEmpty()
    {
        var mockService = new Mock<IElementService>();
        mockService.Setup(s => s.elementalForms(It.IsAny<string>())).ReturnsAsync(new ElementWordForms());

        var controller = new ElementController(mockService.Object);
        var result = await controller.Get("anything");

        var okResult = Assert.IsType<OkObjectResult>(result);
        var value = Assert.IsType<ElementWordForms>(okResult.Value);
        Assert.Empty(value.Forms);
    }
}
