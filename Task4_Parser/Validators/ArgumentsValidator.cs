using System.IO;

namespace Task4_Parser.Validators
{
    public class ArgumentsValidator : IArgumentsValidator
    {
        #region private fields

        private readonly IArgumentsLengthValidator _argumentLengthValidator;

        #endregion

        #region ctor

        public ArgumentsValidator(IArgumentsLengthValidator argumentLengthValidator)
        {
            _argumentLengthValidator = argumentLengthValidator;
        }

        #endregion

        public bool HasValidArguments(string[] args)
        {
            return _argumentLengthValidator.HasValidLength(args) 
                    && File.Exists(args[0]);
        }
    }
}
