using Logger;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Task4_Parser.Models;
using Task4_Parser.Services.Interfaces;

namespace Task4_Parser.Services
{
    public class ParserSwitcher : IParser
    {
        #region private fields

        private List<string> _updateText;

        #endregion

        #region properties

        public List<string> UpdateText { get => _updateText; }

        #endregion

        public int RunText(List<string> lines, IInputArguments arguments)
        {
            var regex = new Regex(arguments.SearchText);
            int count = 0;

            _updateText = new List<string>(lines.Count);

            foreach (var line in lines)
            {
                var entries = regex.Matches(line);
                count += entries.Count;

                string replaceLine = line.Replace(arguments.SearchText, arguments.NewText);
                _updateText.Add(replaceLine);
            }

            return count;
        }
    }
}