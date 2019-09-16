using System;
using System.IO;
using System.Text.RegularExpressions;


namespace Task4_Parser.Services
{
    public class ParserCounter
    {

        public int Calculate(StreamReader streamReader,
                             string searchText)
        {

            if (streamReader == null)
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

            while ((line = streamReader.ReadLine()) != null)
            {
                var entries = regex.Matches(line);
                count += entries.Count;
            }

            return count;
        }
    }
}