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
        private INumberPartFactory NumberPartFactory { get; set; }

        private string zero = "0";
        private string one = "1";

        public AbstractDictionaryWords(INumberPartFactory factory)
        {
            NumberPartFactory = factory;
        }

        public virtual string GetValue(Number number)
        {
            if (number.Value.All(s => s.ToString() == zero))
            {
                return string.Empty;
            }

            var numberPart = NumberPartFactory.Create(number.Value);

            var builder = new StringBuilder();
            int keyHundred = 0;

            if (numberPart.First != zero)
            {
                AppendNumberWord(numberPart.First, builder);
                AppendBitWord(keyHundred, builder);
            }

            if (numberPart.Second != zero)
            {
                if (numberPart.Second == one)
                {
                    AppendNumberWord(numberPart.Second + numberPart.Third, builder);
                }
                else
                {
                    AppendTensWord(numberPart.Second, builder);
                    AppendNumberWord(numberPart.Third, builder);
                }
            }
            else
            {
                if (numberPart.Third != zero)
                {
                    AppendNumberWord(numberPart.Third, builder);
                }
            }

            if (number.Position > keyHundred)
            {
                AppendBitWord(number.Position, builder);
            }
            return builder.ToString();
        }

        private void AppendTensWord(string tens, StringBuilder builder)
        {
            dictionaryTens.TryGetValue(tens, out string valueNumber);
            if (!string.IsNullOrEmpty(valueNumber))
            {
                builder.Append(valueNumber);
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