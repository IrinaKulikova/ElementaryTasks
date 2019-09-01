using System.Collections.Generic;
using Task5_NumberWord.Dictionaries;
using Task5_NumberWord.Models;

namespace Task5_NumberWord.Expressions
{
    public class Context
    {
        public List<NumberPart> Source { get; set; }
        public string Number { get; set; }
        public bool CanInterpret { get; private set; }
        public int Position { get; set; }
        public AbstractDictionaryWords DictionaryWords { get; private set; }
        public List<string> Result { get; set; }

        public Context(AbstractDictionaryWords dictionaryWords, string number)
        {
            Number = number;
            DictionaryWords = dictionaryWords;
            Result = new List<string>();
            Source = new List<NumberPart>();
        }
    }
}
