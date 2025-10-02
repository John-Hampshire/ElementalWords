using Xunit;
using ElementWords.Domain.Models;
using System.Collections.Generic;

public class ElementWordFormsTests
{
    [Fact]
    public void AddSet_AddsSetToForms()
    {
        var forms = new ElementWordForms();
        var set = new List<string> { "Sulfur (S)", "Nitrogen (N)" };
        forms.Forms.Add(set);

        Assert.Single(forms.Forms);
        Assert.Equal(set, forms.Forms[0]);
    }

    [Fact]
    public void RemoveSet_RemovesSetFromForms()
    {
        var forms = new ElementWordForms();
        var set = new List<string> { "Sulfur (S)", "Nitrogen (N)" };
        forms.Forms.Add(set);

        forms.Forms.Remove(set);

        Assert.Empty(forms.Forms);
    }
}
