using System;
using Task4_Parser.Enums;

namespace Task4_Parser.Validators
{
    public class ArgumentsLengthValidator : IArgumentsLengthValidator
    {
        public bool HasValidLength(string[] arguments)
        {
            return IsNotNull(arguments) && IsValidLength(arguments);
        }

        public bool HasNullArguments(string[] arguments)
        {
            return arguments == null || arguments.Length == 0;
        }

        private bool IsValidLength(string[] arguments)
        {
            return Enum.IsDefined(typeof(ValidArgumentsLength), arguments.Length);
        }

        private bool IsNotNull(string[] arguments)
        {
            return !HasNullArguments(arguments);
        }

    }
}
