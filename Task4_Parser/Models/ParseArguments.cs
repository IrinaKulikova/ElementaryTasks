namespace Task4_Parser.Models
{
    public class ParseArguments : IParseArguments
    {
        public string FilePath { get; private set; }
        public string SearchText { get; private set; }
        public string NewText { get; private set; }

        public ParseArguments(string filePath, string searchText, string newText)
        {
            FilePath = filePath;
            SearchText = searchText;
            NewText = newText;
        }
    }
}
