using ElementWords.Domain.Models;
using Xunit;

public class ElementTests
{
    [Fact]
    public void Element_Properties_AreSetCorrectly()
    {
        var element = new Element { Id = 1, Name = "Hydrogen", Symbol = "H" };

        Assert.Equal(1, element.Id);
        Assert.Equal("Hydrogen", element.Name);
        Assert.Equal("H", element.Symbol);
    }
}
