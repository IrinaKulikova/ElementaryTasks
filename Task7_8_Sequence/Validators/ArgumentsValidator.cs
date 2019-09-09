using System.Collections.Generic;

namespace Task7_8_Sequence.Validators
{
    public class ArgumentsValidator : IArgumentsValidator
    {
        #region private fields

        private readonly IEnumerable<IValidator> _validatorsList;

        #endregion

        #region ctor

        public ArgumentsValidator(IEnumerable<IValidator> validatorsList)
        {
            _validatorsList = validatorsList;
        }

        #endregion

        public bool HasValidArguments(string[] args)
        {
            foreach (var validator in _validatorsList)
            {
                if (!validator.IsValid(args))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
