using Task7_8_Sequence.Tests.FixtureClasses;
using Xunit;

namespace Task7_8_Sequence.Tests
{
    public class ArgumentsLengthValidatorTests : IClassFixture<ArgumentsLengthValidatorFixture>
    {
        private ArgumentsLengthValidatorFixture _validatorFixture;

        public ArgumentsLengthValidatorTests(ArgumentsLengthValidatorFixture validatorFixture)
        {
            _validatorFixture = validatorFixture;
        }

        [Theory]
        [InlineData("521", "22")]
        [InlineData("0", "22")]
        [InlineData("2")]
        public void ArgumentsLengthValidator_WithOneOrTwoArguments_ShouldReturnsTrue
                                         (params string[] arguments)
        {
            var isValidLength = _validatorFixture.ArgumentsLengthValidator
                .IsValid(arguments);

            Assert.True(isValidLength);
        }

        [Theory]
        [InlineData("521", "22", "33")]
        [InlineData()]
        [InlineData(null)]
        public void ArgumentsLengthValidator_WithInvalidCountArguments_ShouldReturnsFalse
                                                    (params string[] arguments)
        {
            var isValidLength = _validatorFixture.ArgumentsLengthValidator
                .IsValid(arguments);

            Assert.False(isValidLength);
        }
    }
}
