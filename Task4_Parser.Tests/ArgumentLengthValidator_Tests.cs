using Logger;
using Moq;
using Task4_Parser.Tests.IClassFixtures;
using Task4_Parser.Validators;
using Xunit;

namespace Task4_Parser.Tests
{
    public class ArgumentLengthValidator_Tests : IClassFixture<ArgumentsLengthValidatorFixture>
    {
        private readonly IValidator _validator;

        public ArgumentLengthValidator_Tests(ArgumentsLengthValidatorFixture fakeValidator)
        {
            _validator = fakeValidator.ArgumentsLengthValidator;
        }

        [Theory]
        [InlineData("..//Resources//file.txt", "text")]
        [InlineData("..//Resources//file.txt", "text", "new text")]
        public void test_IsValid_TakeTwoOrThreeArguments_ShouldRetunsTrue
                                                (params string[] arguments)
        {
            bool isValidLength = _validator.IsValid(arguments);

            Assert.True(isValidLength);
        }


        [Theory]
        [InlineData()]
        [InlineData(null)]
        [InlineData("..//Resources//file.txt")]
        [InlineData("..//Resources//file.txt", "text", "new text", "other text")]
        public void test_IsValid_TakesInvalidCountArguments_ShouldRetunsFalse
            (params string[] arguments)
        {
            bool isValidLength = _validator.IsValid(arguments);

            Assert.False(isValidLength);
        }
    }
}
