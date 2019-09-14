using Task7_8_Sequence.Tests.IClassFixtures;
using Xunit;

namespace Task7_8_Sequence.Tests
{
    public class ArgumentsNumbersValidatorTests : IClassFixture<ArgumentsNumberValidatorFixture>
    {
        private ArgumentsNumberValidatorFixture _validatorFixture;

        public ArgumentsNumbersValidatorTests(ArgumentsNumberValidatorFixture validatorFixture)
        {
            _validatorFixture = validatorFixture;
        }

        [Theory]
        [InlineData("521", "22")]
        [InlineData("0", "22")]
        public void ArgumentsNumbersValidator_WithTwoArguments_ShouldReturnsTrue
                                                    (params string[] arguments)
        {
            var areValidNumbers = _validatorFixture.ArgumentsNumberValidator
                                                   .IsValid(arguments);

            Assert.True(areValidNumbers);
        }


        [Theory]
        [InlineData("-521", "-22")]
        [InlineData("0", "-22")]
        public void ArgumentsNumbersValidator_WithNegativeOrZeroValues_ShouldReturnsFalse
                                                    (params string[] arguments)
        {
            var areValidNumbers = _validatorFixture.ArgumentsNumberValidator
                                                              .IsValid(arguments);
            Assert.False(areValidNumbers);
        }


        [Theory]
        [InlineData("0", "-22222222222222222222222")]
        [InlineData("-0.00000000000000000005", "-22222222222222222222222")]
        public void ArgumentsNumbersValidator_WithTooBigOrTooSmallValues_ShouldReturnsFalse
                                                    (params string[] arguments)
        {
            var areValidNumbers = _validatorFixture.ArgumentsNumberValidator
                                                              .IsValid(arguments);
            Assert.False(areValidNumbers);
        }


        [Theory]
        [InlineData(null)]
        public void ArgumentsNumbersValidator_WithNullValue_ShouldReturnsFalse
                                                    (params string[] arguments)
        {
            var areValidNumbers = _validatorFixture.ArgumentsNumberValidator
                                                              .IsValid(arguments);
            Assert.False(areValidNumbers);
        }
    }
}
