using ElementWords.Domain.Models;

namespace ElementWords.Service.Service
{
    public class ElementService : Interface.IElementService
    {
        private readonly HashSet<string> _symbolsLowerCase;
        private readonly Elements _elementList;

        public ElementService()
        {
            _elementList = ElementWords.Data.ElementList.GetAllElements();
            _symbolsLowerCase = _elementList.Items.Select(e => e.Symbol.ToLowerInvariant()).ToHashSet();
        }

        public async Task<ElementWordForms> elementalForms(string word)
        {
            var forms = new ElementWordForms();
            var currentPath = new List<string>();

            if (string.IsNullOrEmpty(word))
            {
                return forms;
            }

            await RecursiveElementalFormsSearch(word.ToLowerInvariant(), 0, currentPath, forms);

            return forms;
        }

        private async Task RecursiveElementalFormsSearch(string word, int startIndex, List<string> currentPath, ElementWordForms results)
        {
            // Base case: we've successfully processed the entire word
            if (startIndex == word.Length)
            {
                results.Forms.Add(new List<string>(currentPath));
                return;
            }

            // Try matching 1-character element symbols
            await TryMatchNChars(word, startIndex, 1, currentPath, results);

            // Try matching 2-character element symbols
            await TryMatchNChars(word, startIndex, 2, currentPath, results);

            // Try matching 3-character element symbols
            await TryMatchNChars(word, startIndex, 3, currentPath, results);
        }

        private async Task TryMatchNChars(string word, int startIndex, int n, List<string> currentPath, ElementWordForms results)
        {
            if (startIndex + n <= word.Length)
            {
                var segment = word.Substring(startIndex, n).ToLowerInvariant();
                if (_symbolsLowerCase.Contains(segment))
                {
                    currentPath.Add(FormatEntry(_elementList.Items.Where(e => e.Symbol == CapitalizeSymbol(segment)).FirstOrDefault()!));
                    await RecursiveElementalFormsSearch(word, startIndex + n, currentPath, results);
                    currentPath.RemoveAt(currentPath.Count - 1);
                }
            }
        }

        private static string CapitalizeSymbol(string symbol)
        {
            if (string.IsNullOrEmpty(symbol))
                return symbol;

            return char.ToUpperInvariant(symbol[0]) + symbol[1..].ToLowerInvariant();
        }

        private static string FormatEntry(Element found)
        {
            return $"{found.Name} ({found.Symbol})";
        }
    }
}
