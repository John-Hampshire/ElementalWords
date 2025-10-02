using Xunit;
using ElementWords.Service.Service;
using ElementWords.Domain.Models;
using System.Threading.Tasks;

public class ElementServiceTests
{
    [Fact]
    public async Task ElementalForms_ReturnsEmpty_WhenWordIsNullOrEmpty()
    {
        var service = new ElementService();

        var resultNull = await service.elementalForms(null);
        var resultEmpty = await service.elementalForms("");

        Assert.NotNull(resultNull);
        Assert.Empty(resultNull.Forms);

        Assert.NotNull(resultEmpty);
        Assert.Empty(resultEmpty.Forms);
    }

    [Fact]
    public async Task ElementalForms_ReturnsCorrectForms_ForValidWord()
    {
        var service = new ElementService();
        var result = await service.elementalForms("snack");

        Assert.NotNull(result);
        Assert.All(result.Forms, set =>
        {
            Assert.All(set, entry =>
            {
                Assert.Contains("(", entry);
                Assert.Contains(")", entry);
            });
        });
        Assert.Equal(3, result.Forms.Count);
    }

    [Fact]
    public async Task ElementalForms_ReturnsNoForms_ForNonElementWord()
    {
        var service = new ElementService();
        var result = await service.elementalForms("zzzz");

        Assert.NotNull(result);
        Assert.Empty(result.Forms);
    }
}
