using Task7_8_Sequence.Tests.IClassFixtures;
using Xunit;

namespace Task7_8_Sequence.Tests
{
    public class ArgumentsNumbersValidator_Tests : IClassFixture<ArgumentsNumberValidatorFixture>
    {
        private ArgumentsNumberValidatorFixture _validatorFixture;

        public ArgumentsNumbersValidator_Tests(ArgumentsNumberValidatorFixture validatorFixture)
        {
            _validatorFixture = validatorFixture;
        }

        [Theory]
        [InlineData("521", "22")]
        [InlineData("0", "22")]
        public void test_IsValid_TakesTwoValidArguments_ShouldReturnsTrue
                                                    (params string[] arguments)
        {
            var areValidNumbers = _validatorFixture.ArgumentsNumberValidator
                                                   .IsValid(arguments);

            Assert.True(areValidNumbers);
        }


        [Theory]
        [InlineData()]
        [InlineData("-521", "-22")]
        [InlineData("0", "-22")]
        [InlineData("0", "-22222222222222222222222")]
        [InlineData("-0.00000000000000000005", "-22222222222222222222222")]
        public void test_IsValid_TakesInvalidArguments_ShouldReturnsFalse
                                                    (params string[] arguments)
        {
            var areValidNumbers = _validatorFixture.ArgumentsNumberValidator
                                                              .IsValid(arguments);
            Assert.False(areValidNumbers);
        }
    }
}
