using System.Collections.Generic;
using System.Text;
using Task5_NumberWord.Dictionaries;
using Task5_NumberWord.Models;
using Task5_NumberWord.Services.Interfaces;

namespace Task5_NumberWord.Services
{
    public class ConverterNumber : IConverterNumber
    {
        #region

        private readonly IEnumerable<NumberPart> numberParts = null;
        private readonly AbstractDictionaryWords dictionary = null;

        #endregion

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
