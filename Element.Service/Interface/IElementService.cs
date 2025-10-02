using ElementWords.Domain.Models;

namespace ElementWords.Service.Interface
{
    public interface IElementService
    {
        public Task<ElementWordForms> elementalForms(string word);
    }
}
