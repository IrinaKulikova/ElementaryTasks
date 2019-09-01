using System;
using System.Collections.Generic;
using Task5_NumberWord.Enums;
using Task5_NumberWord.Services.Interfaces;

namespace Task5_NumberWord.Services
{
    public class ArgumentsValidator : IArgumentsValidator
    {

        public bool Check(string[] args)
        {
            return IsValidLength(args) && IsNumber(args[0]);
        }

        private bool IsNumber(string number)
        {
            return int.TryParse(number, out int value);
        }

        private bool IsValidLength(string[] args)
        {
            return args?.Length == (int)ValidArgumentsLength.Number
                || args?.Length == (int)ValidArgumentsLength.NumberLanguage;
        }
    }
}