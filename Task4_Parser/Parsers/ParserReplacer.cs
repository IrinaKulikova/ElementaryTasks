using System;
using System.IO;

namespace Task4_Parser.Services
{
    public class ParserReplacer
    {
        public void Replace(StreamWriter streamWriter,
                            StreamReader streamReader,
                            string searchText, string newText)
        {
            string line = String.Empty;

            do
            {
                line = streamReader.ReadLine();

                if (line != null)
                {
                    string replaceLine = line.Replace(searchText, newText);
                    streamWriter.WriteLine(replaceLine);
                }

            } while (line != null);
        }
    }
}