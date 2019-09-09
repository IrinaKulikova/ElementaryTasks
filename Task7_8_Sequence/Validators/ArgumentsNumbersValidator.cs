using System;

namespace Task7_8_Sequence.Validators
{
    public class ArgumentsNumbersValidator : IValidator
    {
        public bool IsValid(string[] arguments)
        {
            for (int i = 0; i < arguments.Length; i++)
            {
                if (!(Int32.TryParse(arguments[i], out int buffer) && buffer >= 0))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
