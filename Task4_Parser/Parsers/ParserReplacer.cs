using System;
using System.IO;
using System.Text;

namespace Task4_Parser.Services
{
    public class ParserReplacer
    {

        public string Replace(StreamWriter streamWriter,
                              StreamReader streamReader,
                              string searchText, string newText)
        {
            if (streamReader == null)
            {
                throw new NullReferenceException("StreamReader is null");
            }

            if (streamWriter == null)
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

            string line = String.Empty;
            var updateText = new StringBuilder();

            while ((line = streamReader.ReadLine()) != null)
            {
                string replacedLine = line.Replace(searchText, newText);
                updateText.Append(replacedLine + "\n");
                streamWriter.WriteLine(replacedLine);
            }
            return updateText.ToString();
        }
    }
}