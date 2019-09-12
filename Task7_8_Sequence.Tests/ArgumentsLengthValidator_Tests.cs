using Task7_8_Sequence.Tests.IClassFixtures;
using Xunit;

namespace Task7_8_Sequence.Tests
{
    public class ArgumentsLengthValidator_Tests : IClassFixture<ArgumentsLengthValidatorFixture>
    {
        private ArgumentsLengthValidatorFixture _validatorFixture;

        public ArgumentsLengthValidator_Tests(ArgumentsLengthValidatorFixture validatorFixture)
        {
            _validatorFixture = validatorFixture;
        }

        [Theory]
        [InlineData("521", "22")]
        [InlineData("0", "22")]
        [InlineData("2")]
        public void test_IsValid_TakeOneOrTwoArguments_ShouldReturnsTrue
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
        public void test_IsValid_TakeInvalidCountArguments_ShouldReturnsFalse
                                                    (params string[] arguments)
        {
            var isValidLength = _validatorFixture.ArgumentsLengthValidator
                .IsValid(arguments);

            Assert.False(isValidLength);
        }
    }
}
