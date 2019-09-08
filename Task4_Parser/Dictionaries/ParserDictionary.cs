using System;
using System.Collections.Generic;
using Task4_Parser.Enums;
using Task4_Parser.Models;
using Task4_Parser.Services;

namespace Task4_Parser.Dictionaries
{
    public class ParserDictionary : IParserDictionary
    {
        private readonly IDictionary<ValidArgumentsLength, Func<IInputArguments, int>> _dictionary;

        public ParserDictionary()
        {
            _dictionary = new Dictionary<ValidArgumentsLength, Func<IInputArguments, int>>();
            _dictionary.Add(ValidArgumentsLength.FileSearch, GetCountEntries);
            _dictionary.Add(ValidArgumentsLength.FileSearchReplace, GetCountEntriesAndReplace);
        }

        public int GetCount(IInputArguments argumentsLength)
        {
            Func<IInputArguments, int> function = null;

            if (_dictionary.TryGetValue(argumentsLength.ArgumentsLength, out function))
            {
                return function(argumentsLength);
            }

            throw new ArgumentException();
        }


        public int GetCountEntriesAndReplace(IInputArguments arguments)
        {
            int count;
            using (var fileWorker = new FileStreamSwitcher(arguments))
            {
                var lines = fileWorker.GetText();
                var parser = new ParserSwitcher();
                count = parser.RunText(lines, arguments);
                fileWorker.SetText(parser.UpdateText, arguments);
            }

            return count;
        }


        public int GetCountEntries(IInputArguments arguments)
        {
            int count;
            using (var fileWorker = new FileStreamCounter(arguments))
            {
                var lines = fileWorker.GetText();
                var parser = new ParserCounter();
                count = parser.RunText(lines, arguments);
            }

            return count;
        }
    }
}
