using Task7_8_Sequence.Tests.IClassFixtures;
using Xunit;

namespace Task7_8_Sequence.Tests
{
    public class ArgumentsNotNullValidator_Tests : IClassFixture<ArgumentsLengthValidatorFixture>
    {
        private ArgumentsLengthValidatorFixture _validatorFixture;

        public ArgumentsNotNullValidator_Tests(ArgumentsLengthValidatorFixture validatorFixture)
        {
            _validatorFixture = validatorFixture;
        }


        [Theory]
        [InlineData("521", "22")]
        [InlineData("0", "22")]
        [InlineData("0")]
        public void IsValid_TakeValidArguments_ShouldReturnsTrue
                                            (params string[] arguments)
        {
            var notNull = _validatorFixture.ArgumentsLengthValidator
                                           .IsValid(arguments);

            Assert.True(notNull);
        }


        [Theory]
        [InlineData(null)]
        public void IsValid_TakeNullArguments_ShouldReturnsFalse
                                            (params string[] arguments)
        {
            var notNull = _validatorFixture.ArgumentsLengthValidator
                                                       .IsValid(arguments);
            Assert.False(notNull);
        }
    }
}
