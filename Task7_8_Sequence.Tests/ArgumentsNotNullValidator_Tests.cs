using Task7_8_Sequence.Validators;
using Xunit;

namespace Task7_8_Sequence.Tests
{
    public class ArgumentsNotNullValidator_Tests
    {
        [Theory]
        [InlineData("521", "22")]
        [InlineData("0", "22")]
        [InlineData("0")]
        public void NotNull_Success(params string[] arguments)
        {
            var validator = new ArgumentsNotNullValidator();

            bool notNull = validator.IsValid(arguments);

            Assert.True(notNull);
        }


        [Fact]
        public void Numbers_Null_Fail()
        {
            var validator = new ArgumentsNotNullValidator();

            bool notNull = validator.IsValid(null);

            Assert.False(notNull);
        }
    }
}
