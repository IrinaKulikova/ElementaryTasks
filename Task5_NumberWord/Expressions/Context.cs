using System.Collections.Generic;
using Task5_NumberWord.Containers;
using Task5_NumberWord.Dictionaries;

namespace Task5_NumberWord.Expressions
{
    public class Context
    {
        public NumberCollection Source { get; set; }
        public bool CanInterpret { get; private set; }
        public int Position { get; set; }
        public AbstractDictionaryWords DictionaryWords { get; private set; }
        public List<string> Result { get; set; }

        public Context(string number, AbstractDictionaryWords dictionaryWords)
        {
            Source = new NumberCollection(number);
            DictionaryWords = dictionaryWords;
            Result = new List<string>();
        }
    }
}
