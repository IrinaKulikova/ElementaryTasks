using Task7_8_Sequence.Tests.FixtureClasses;
using Xunit;

namespace Task7_8_Sequence.Tests
{
    public class ArgumentsNotNullValidatorTests : IClassFixture<ArgumentsLengthValidatorFixture>
    {
        private ArgumentsLengthValidatorFixture _validatorFixture;

        public ArgumentsNotNullValidatorTests(ArgumentsLengthValidatorFixture validatorFixture)
        {
            _validatorFixture = validatorFixture;
        }


        [Theory]
        [InlineData("521", "22")]
        [InlineData("0", "22")]
        [InlineData("0")]
        public void ArgumentsNotNullValidator_WithNotNullArguments_ShouldReturnsTrue
                                            (params string[] arguments)
        {
            var notNull = _validatorFixture.ArgumentsLengthValidator
                                           .IsValid(arguments);

            Assert.True(notNull);
        }


        [Theory]
        [InlineData(null)]
        public void ArgumentsNotNullValidator_WithNullArguments_ShouldReturnsFalse
                                            (params string[] arguments)
        {
            var notNull = _validatorFixture.ArgumentsLengthValidator
                                                       .IsValid(arguments);
            Assert.False(notNull);
        }
    }
}
