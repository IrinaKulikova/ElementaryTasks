using System.Collections.Generic;
using Task7_8_Sequence.Validators;
using Xunit;

namespace Task7_8_Sequence.Tests
{
    public class ArgumentsValidator_Tests
    {
        [Theory]
        [InlineData("3", "9")]
        [InlineData("39", "9")]
        [InlineData("9")]
        public void IsValid_Success(params string[] arguments)
        {
            ArgumentsValidator argumentsValidator = GetValidator();

            var result = argumentsValidator.HasValidArguments(arguments);

            Assert.True(result);
        }

        [Theory]
        [InlineData("3", "9", "999")]
        [InlineData()]
        public void IsValid_Fail(params string[] arguments)
        {
            ArgumentsValidator argumentsValidator = GetValidator();

            var result = argumentsValidator.HasValidArguments(arguments);

            Assert.False(result);
        }

        private static ArgumentsValidator GetValidator()
        {
            var validatorList = new List<IValidator>()
            {
                new ArgumentsNotNullValidator(),
                new ArgumentsLengthValidator(),
                new ArgumentsNumbersValidator()
            };

            var argumentsValidator = new ArgumentsValidator(validatorList);
            return argumentsValidator;
        }
    }
}
