using Task7_8_Sequence.Enums;

namespace Task7_8_Sequence.Validators
{
    public class ArgumentsLengthValidator : IValidator
    {
        public bool IsValid(string[] arguments)
        {
            if (arguments == null || arguments.Length == 0)
            {
                return false;
            }

            return HasOneLimit(arguments) || HasTwoLimit(arguments);
        }


        private bool HasOneLimit(string[] arguments)
        {
            return CountArguments.OneLimits ==
                   (CountArguments)arguments.Length;
        }

        private bool HasTwoLimit(string[] arguments)
        {
            return CountArguments.TwoLimits ==
                   (CountArguments)arguments.Length;
        }
    }
}
