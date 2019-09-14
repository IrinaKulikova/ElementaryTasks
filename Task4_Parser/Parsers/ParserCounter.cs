using System;
using System.IO;
using System.Text.RegularExpressions;


namespace Task4_Parser.Services
{
    public class ParserCounter
    {
        #region private fields

        private readonly StreamReader _streamReader;

        #endregion

        #region ctor

        public ParserCounter(StreamReader streamReader)
        {
            _streamReader = streamReader;
        }

        #endregion

        public int Calculate(string searchText)
        {
            if (_streamReader == null)
            {
                throw new NullReferenceException("StreamReader is null");
            }

            if (searchText == null)
            {
                throw new NullReferenceException("SearchText is null");
            }

            var line = String.Empty;
            var regex = new Regex(searchText);
            int count = 0;

            while ((line = _streamReader.ReadLine()) != null)
            {
                var entries = regex.Matches(line);
                count += entries.Count;
            }

            return count;
        }
    }
}