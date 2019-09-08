namespace Task4_Parser.Models
{
    public class ParseArguments : IParseArguments
    {
        #region private fields

        private readonly string _filePath;
        private readonly string _searchText;
        private readonly string _newText;

        #endregion

        #region properties

        public string FilePath { get => _filePath; }
        public string SearchText { get => _searchText; }
        public string NewText { get => _newText; }

        #endregion

        public ParseArguments(string filePath, string searchText, string newText)
        {
            _filePath = filePath;
            _searchText = searchText;
            _newText = newText;
        }
    }
}
