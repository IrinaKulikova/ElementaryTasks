using System.IO;
using Task4_Parser.Models;
using Task4_Parser.Services.Interfaces;

namespace Task4_Parser.Services
{
    public class ReaderParser : IParser
    {
        public int IterateOver(ParseArguments arguments)
        {
            var bufferSize = 1024;
            int offset = 0;
            int count = 0;

            using (Stream stream = new FileStream(arguments.FilePath, FileMode.Open, FileAccess.ReadWrite))
            {
                byte[] dataArray = new byte[bufferSize];
                int length = 0;
                while ((length = stream.Read(dataArray, offset, bufferSize)) > 0)
                {
                    string bufferedText = System.Text.Encoding.UTF8.GetString(dataArray);
                    int index = 0;

                    while ((index = bufferedText.IndexOf(arguments.SearchText, index)) != -1)
                    {
                        index += arguments.SearchText.Length;
                        count++;
                        if (!string.IsNullOrEmpty(arguments.NewText))
                        {
                            bufferedText = NewMethod(arguments.SearchText, arguments.NewText, bufferedText);
                        }
                    }
                } while (length > 0) ;
            }
            return count;
        }

        private static string NewMethod(string searchText, string newText, string bufferedText)
        {
            if (newText != null)
            {
                bufferedText = bufferedText.Replace(searchText, newText);
            }
            return bufferedText;
        }

        protected virtual void ReplaceHook(string newText, string oldText, string source, int index) { }
    }
}
