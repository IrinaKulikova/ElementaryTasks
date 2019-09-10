using Task4_Parser.Models;

namespace Task4_Parser.Services
{
    public class ParserReplacer
    {
        public string Replace(string line, IInputArguments arguments)
        {
            return line.Replace(arguments.SearchText, arguments.NewText);
        }
    }
}