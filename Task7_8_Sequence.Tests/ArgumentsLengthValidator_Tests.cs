using Task7_8_Sequence.Validators;
using Xunit;

namespace Task7_8_Sequence.Tests
{
    public class ArgumentsLengthValidator_Tests
    {
        [Theory]
        [InlineData("521", "22")]
        [InlineData("0", "22")]
        [InlineData("2")]
        public void Length_Success(params string[] arguments)
        {
            var validator = new ArgumentsLengthValidator();

            bool length = validator.IsValid(arguments);

            Assert.True(length);
        }

        [Theory]
        [InlineData("521", "22", "33")]
        [InlineData()]
        public void Length_Fail(params string[] arguments)
        {
            var validator = new ArgumentsLengthValidator();

            bool length = validator.IsValid(arguments);

            Assert.False(length);
        }


        [Fact]
        public void Numbers_Null_False()
        {
            var validator = new ArgumentsLengthValidator();

            bool length = validator.IsValid(null);

            Assert.False(length);
        }
    }
}
