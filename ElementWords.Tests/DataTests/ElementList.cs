using ElementWords.Data;
using Xunit;

public class ElementListTests
{
    [Fact]
    public void GetAllElements_ReturnsAllElements()
    {
        var elements = ElementList.GetAllElements();

        Assert.NotNull(elements);
        Assert.NotNull(elements.Items);
        Assert.True(elements.Items.Count == 118); // Should contain all periodic elements
    }
}
