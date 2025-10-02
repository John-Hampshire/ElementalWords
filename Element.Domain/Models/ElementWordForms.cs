namespace ElementWords.Domain.Models
{
    public class ElementWordForms
    {
        public List<List<string>> Forms { get; set; }

        public ElementWordForms() { Forms = new List<List<string>>(); }
    }
}
