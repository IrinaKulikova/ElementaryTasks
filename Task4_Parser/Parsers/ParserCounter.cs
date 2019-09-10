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
            string line = String.Empty;
            int count = 0;

            do
            {
                line = streamReader.ReadLine();

                if (line != null)
                {
                    var regex = new Regex(searchText);
                    var entries = regex.Matches(line);
                    count += entries.Count;
                }

            } while (line != null);

            return count;
        }
    }
}