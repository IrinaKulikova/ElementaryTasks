﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task5_NumberWord.Factories.Interfaces;
using Task5_NumberWord.Models;

namespace Task5_NumberWord.Dictionaries
{
    public abstract class AbstractDictionaryWords
    {
        #region private fields

        private readonly IDigitsFactory _numberPartFactory;
        private readonly string _zero = "0";
        private readonly string _one = "1";

        #endregion

        #region proptected properties

        readonly protected IDictionary<string, string> dictionaryNumbers = new Dictionary<string, string>();
        readonly protected IDictionary<string, string> dictionaryTens = new Dictionary<string, string>();
        readonly protected IDictionary<int, string> dictionaryBits = new Dictionary<int, string>();

        #endregion

        #region ctor

        public AbstractDictionaryWords(IDigitsFactory numberPartFactory)
        {
            _numberPartFactory = numberPartFactory;
        }

        #endregion

        public virtual string GetValue(NumberPart numberPart)
        {
            if (numberPart.Value.All(s => s.ToString() == _zero))
            {
                return string.Empty;
            }

            var digits = _numberPartFactory.Create(numberPart.Value);

            var builder = new StringBuilder();
            int keyHundred = 0;

            if (digits.First != _zero)
            {
                appendNumberWord(digits.First, builder);
                appendBitWord(keyHundred, builder);
            }

            if (digits.Second != _zero)
            {
                if (digits.Second == _one)
                {
                    appendNumberWord(digits.Second + digits.Third, builder);
                }
                else
                {
                    appendTensWord(digits.Second, builder);
                    appendNumberWord(digits.Third, builder);
                }
            }
            else
            {
                appendNumberWord(digits.Third, builder);
            }

            if (numberPart.Position > keyHundred)
            {
                appendBitWord(numberPart.Position, builder);
            }

            return builder.ToString();
        }

        private void appendTensWord(string tens, StringBuilder builder)
        {
            dictionaryTens.TryGetValue(tens, out string valueTens);
            if (!string.IsNullOrEmpty(valueTens))
            {
                builder.Append(valueTens);
                builder.Append(" ");
            }
        }

        private void appendBitWord(int position, StringBuilder builder)
        {
            dictionaryBits.TryGetValue(position, out string bits);
            if (!string.IsNullOrEmpty(bits))
            {
                builder.Append(bits);
                builder.Append(" ");
            }
        }

        private void appendNumberWord(string numberPart, StringBuilder builder)
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