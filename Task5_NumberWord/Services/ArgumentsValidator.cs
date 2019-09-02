using System;
using Task5_NumberWord.Enums;
using Task5_NumberWord.Services.Interfaces;

namespace Task5_NumberWord.Services
{
    public class ArgumentsValidator : IArgumentsValidator
    {

        public bool Check(string[] args)
        {
            return IsValidLength(args) && FirstIsNumber(args[0]) && SecondIsValid(args);
        }

        private bool FirstIsNumber(string number)
        {
            return int.TryParse(number, out int value);
        }

        private bool IsValidLength(string[] args)
        {
            return CheckOneArgument(args) || CheckTwoArguments(args);
        }

        private bool CheckOneArgument(string[] args)
        {
            return args.Length == (int)ValidArgumentsLength.Number;
        }

        private bool CheckTwoArguments(string[] args)
        {
            return args.Length == (int)ValidArgumentsLength.NumberLanguage;
        }

        private bool SecondIsLanguage(string[] args)
        {
            return CheckTwoArguments(args) && Enum.IsDefined(typeof(Language), args[1]);
        }

        private bool SecondIsValid(string[] args)
        {
            return SecondIsLanguage(args) || CheckOneArgument(args);
        }
    }
}