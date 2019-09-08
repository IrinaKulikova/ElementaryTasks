using Logger;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Task4_Parser.Models;
using Task4_Parser.Services.Interfaces;

namespace Task4_Parser.Services
{
    public class ParserCounter : IParser
    {
        public int RunText(List<string> lines, IInputArguments arguments)
        {
            var regex = new Regex(arguments.SearchText);
            int count = 0;

            foreach (var line in lines)
            {
                var entries = regex.Matches(line);
                count += entries.Count;
            }

            return count;
        }
    }
}