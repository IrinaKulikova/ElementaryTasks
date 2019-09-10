using System.Text.RegularExpressions;
using Task4_Parser.Models;

namespace Task4_Parser.Services
{
    public class ParserCounter
    {
        public int Calculate(string line, IInputArguments arguments)
        {
            var regex = new Regex(arguments.SearchText);

            var entries = regex.Matches(line);

            return entries.Count;
        }
    }
}