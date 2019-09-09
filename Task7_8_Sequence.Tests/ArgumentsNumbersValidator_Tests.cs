using Task7_8_Sequence.Validators;
using Xunit;

namespace Task7_8_Sequence.Tests
{
    public class ArgumentsNumbersValidator_Tests
    {
        [Theory]
        [InlineData("521", "22")]
        [InlineData("0", "22")]
        public void HasNumbers_Success(params string[] arguments)
        {
            var validator = new ArgumentsNumbersValidator();

            bool numbers = validator.IsValid(arguments);

            Assert.True(numbers);
        }


        [Theory]
        [InlineData("-521", "-22")]
        [InlineData("0", "-22")]
        [InlineData("0", "-22222222222222222222222")]
        [InlineData("-0.00000000000000000005", "-22222222222222222222222")]
        public void Numbers_Fail(params string[] arguments)
        {
            var validator = new ArgumentsNumbersValidator();

            bool numbers = validator.IsValid(arguments);

            Assert.False(numbers);
        }


        [Theory]
        [InlineData()]
        public void Numbers_Null_True(params string[] arguments)
        {
            var validator = new ArgumentsNumbersValidator();

            bool numbers = validator.IsValid(arguments);

            Assert.True(numbers);
        }
    }
}
