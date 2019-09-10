using Task4_Parser.Enums;

namespace Task4_Parser.Models
{
    public class InputArguments : IInputArguments
    {
        #region private fields

        private readonly string _filePath;
        private readonly string _searchText;
        private readonly string _newText;
        private readonly ValidArgumentsLength _argumentsLength;

        #endregion

        #region properties

        public string FilePath { get => _filePath; }
        public string SearchText { get => _searchText; }
        public string NewText { get => _newText; }
        public ValidArgumentsLength ArgumentsLength { get => _argumentsLength; }

        #endregion

        public InputArguments(string filePath, 
                              string searchText,
                              string newText, 
                              ValidArgumentsLength argumentsLength)
        {
            _filePath = filePath;
            _searchText = searchText;
            _newText = newText;
            _argumentsLength = argumentsLength;
        }
    }
}
