using System;
using System.IO;
using System.Text;

namespace Task4_Parser.Services
{
    public class ParserReplacer
    {
        #region private fields

        private readonly StreamWriter _streamWriter;
        private readonly StreamReader _streamReader;

        #endregion

        #region ctor

        public ParserReplacer(StreamWriter streamWriter,
                              StreamReader streamReader)
        {
            _streamReader = streamReader;
            _streamWriter = streamWriter;
        }

        #endregion

        public string Replace(string searchText, string newText)
        {
            if (_streamReader == null)
            {
                throw new NullReferenceException("StreamReader is null");
            }

            if (_streamWriter == null)
            {
                throw new NullReferenceException("StreamWriter is null");
            }

            if (searchText == null)
            {
                throw new NullReferenceException("SearchText is null");
            }

            if (newText == null)
            {
                throw new NullReferenceException("NewText is null");
            }

            var updateText = new StringBuilder();
            var line = String.Empty;

            while ((line = _streamReader.ReadLine()) != null)
            {
                var replacedLine = line.Replace(searchText, newText);
                updateText.Append(replacedLine + "\n");
                _streamWriter.WriteLine(replacedLine);
            }

            return updateText.ToString();
        }
    }
}