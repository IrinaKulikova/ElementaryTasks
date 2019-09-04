using System.Collections.Generic;
using System.Text;
using Task5_NumberWord.Dictionaries;
using Task5_NumberWord.Factories.Interfaces;
using Task5_NumberWord.Models;
using Task5_NumberWord.Services.Interfaces;

namespace Task5_NumberWord.Services
{
    public class ConverterNumber : IConverterNumber
    {
        readonly IEnumerable<NumberPart> numberParts = null;
        readonly AbstractDictionaryWords dictionary = null;

        public ConverterNumber(AbstractDictionaryWords dictionary,
                               IEnumerable<NumberPart> numberParts)
        {
            this.numberParts = numberParts;
            this.dictionary = dictionary;
        }

        public string GetWord()
        {
            var resultText = new StringBuilder();

            foreach (var part in numberParts)
            {
                resultText.Append(dictionary.GetValue(part));
            }

            return resultText.ToString();
        }
    }
}
