using System.Collections.Generic;
using System.Text;
using Task5_NumberWord.Dictionaries;
using Task5_NumberWord.Models;
using Task5_NumberWord.Services.Interfaces;

namespace Task5_NumberWord.Services
{
    public class ConverterNumber : IConverterNumber
    {
        #region private fields

        private readonly IEnumerable<NumberPart> _numberParts;
        private readonly AbstractDictionaryWords _dictionary;

        #endregion

        #region ctor

        public ConverterNumber(AbstractDictionaryWords dictionary,
                               IEnumerable<NumberPart> numberParts)
        {
            _numberParts = numberParts;
            _dictionary = dictionary;
        }

        #endregion

        public string GetWord()
        {
            var resultText = new StringBuilder();

            foreach (var part in _numberParts)
            {
                resultText.Append(_dictionary.GetValue(part));
            }

            return resultText.ToString();
        }
    }
}
