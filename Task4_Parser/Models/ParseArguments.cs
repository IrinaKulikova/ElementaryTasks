namespace Task4_Parser.Models
{
    public class ParseArguments
    {
        public string FilePath { get; set; }
        public string SearchText { get; set; }
        public string NewText { get; set; }

        public ParseArguments(string filePath, string searchText, string newText)
        {
            FilePath = filePath;
            SearchText = searchText;
            NewText = newText;
        }
    }
}
