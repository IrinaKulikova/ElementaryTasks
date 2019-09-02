using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task5_NumberWord.Factories.Interfaces;
using Task5_NumberWord.Models;

namespace Task5_NumberWord.Dictionaries
{
    public abstract class AbstractDictionaryWords
    {
        public IDictionary<string, string> dictionaryNumbers = new Dictionary<string, string>();
        public IDictionary<string, string> dictionaryTens = new Dictionary<string, string>();
        public IDictionary<int, string> dictionaryBits = new Dictionary<int, string>();

        private IDigitsFactory NumberPartFactory { get; set; }

        private string zero = "0";
        private string one = "1";

        public AbstractDictionaryWords(IDigitsFactory factory)
        {
            NumberPartFactory = factory;
        }

        public virtual string GetValue(NumberPart numberPart)
        {
            if (numberPart.Value.All(s => s.ToString() == zero))
            {
                return string.Empty;
            }

            var digits = NumberPartFactory.Create(numberPart.Value);

            var builder = new StringBuilder();
            int keyHundred = 0;

            if (digits.First != zero)
            {
                AppendNumberWord(digits.First, builder);
                AppendBitWord(keyHundred, builder);
            }

            if (digits.Second != zero)
            {
                if (digits.Second == one)
                {
                    AppendNumberWord(digits.Second + digits.Third, builder);
                }
                else
                {
                    AppendTensWord(digits.Second, builder);
                    AppendNumberWord(digits.Third, builder);
                }
            }
            else
            {
                AppendNumberWord(digits.Third, builder);
            }

            if (numberPart.Position > keyHundred)
            {
                AppendBitWord(numberPart.Position, builder);
            }

            return builder.ToString();
        }

        private void AppendTensWord(string tens, StringBuilder builder)
        {
            dictionaryTens.TryGetValue(tens, out string valueTens);
            if (!string.IsNullOrEmpty(valueTens))
            {
                builder.Append(valueTens);
                builder.Append(" ");
            }
        }

        private void AppendBitWord(int position, StringBuilder builder)
        {
            dictionaryBits.TryGetValue(position, out string bits);
            if (!string.IsNullOrEmpty(bits))
            {
                builder.Append(bits);
                builder.Append(" ");
            }
        }

        private void AppendNumberWord(string numberPart, StringBuilder builder)
        {
            dictionaryNumbers.TryGetValue(numberPart, out string valueNumber);
            if (!string.IsNullOrEmpty(valueNumber))
            {
                builder.Append(valueNumber);
                builder.Append(" ");
            }
        }
    }
}