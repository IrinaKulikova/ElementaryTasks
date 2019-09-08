using System;
using Task8_Fibonacci.Enums;

namespace Task8_Fibonacci.Validators
{
    public class ArgumentsValidator : IArgumentsValidator
    {
        public bool HasNumbers(string[] args)
        {
            if (args == null)
            {
                return false;
            }

            for (int i = 0; i < args.Length; i++)
            {
                if (!Int32.TryParse(args[i], out int buffer))
                {
                    return false;
                }
            }

            return true;
        }

        public bool HasTwoArguments(string[] args)
        {
            if (args == null)
            {
                return false;
            }

            return CountArguments.Valid == (CountArguments)args.Length;
        }
    }
}
