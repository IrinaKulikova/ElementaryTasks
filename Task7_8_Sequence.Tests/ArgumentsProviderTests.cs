using Logger;
using Moq;
using Task7_8_Sequence.Factories;
using Task7_8_Sequence.Models;
using Task7_8_Sequence.Providers;
using Task7_8_Sequence.Validators;
using Xunit;

namespace Task7_8_Sequence.Tests
{
    public class ArgumentsProviderTests
    {
        [Fact]
        public void ArgumentsProvider_WithTwoArguments_ShouldCallHasValidArguments()
        {
            var arguments = new string[] { "5", "8" };

            var mockValidator = new Mock<IArgumentsValidator>();
            mockValidator.Setup(v => v.HasValidArguments(arguments))
                                            .Returns(It.IsAny<bool>());

            var mockSequenceFactory = new Mock<ISequenceLimitFactory>();
            var mockLogger = new Mock<ILogger>();

            var provider = new ArgumentsProvider(mockValidator.Object,
                                                 mockSequenceFactory.Object,
                                                 mockLogger.Object);

            provider.GetLimits(arguments);

            mockValidator.Verify(v => v.HasValidArguments(arguments), Times.Once);
        }



        [Theory]
        [InlineData("5","15")]
        public void ArgumentsProvider_WithTwoValidArguments_ShouldCallCreateLimits(
                                            params string[] arguments)
        {
            var mockValidator = new Mock<IArgumentsValidator>();
            mockValidator.Setup(v => v.HasValidArguments(arguments))
                                            .Returns(true);

            var mockSequenceFactory = new Mock<ISequenceLimitFactory>();
            mockSequenceFactory.Setup(f => f.Create(arguments))
                               .Returns(It.IsAny<ISequenceLimit>());

            var mockLogger = new Mock<ILogger>();

            var provider = new ArgumentsProvider(mockValidator.Object,
                                                 mockSequenceFactory.Object,
                                                 mockLogger.Object);

            provider.GetLimits(arguments);

            mockValidator.Verify(v => v.HasValidArguments(arguments), Times.Once);
            mockSequenceFactory.Verify(f => f.Create(arguments),Times.Once);
        }


        [Theory]
        [InlineData("5", "15", "50")]
        [InlineData("aa")]
        [InlineData("-5", "-2222222222222222222222222222222222222222222")]
        [InlineData(null)]
        public void ArgumentsProvider_WithOutValidArguments_ShouldNotCallCreateLimits(
                                                params string[] arguments)
        {
            var mockValidator = new Mock<IArgumentsValidator>();
            mockValidator.Setup(v => v.HasValidArguments(arguments))
                                            .Returns(false);

            var mockSequenceFactory = new Mock<ISequenceLimitFactory>();
            mockSequenceFactory.Setup(f => f.Create(arguments))
                               .Returns(It.IsAny<ISequenceLimit>());

            var mockLogger = new Mock<ILogger>();

            var provider = new ArgumentsProvider(mockValidator.Object,
                                                 mockSequenceFactory.Object,
                                                 mockLogger.Object);

            provider.GetLimits(arguments);

            mockValidator.Verify(v => v.HasValidArguments(arguments), Times.Once);
            mockSequenceFactory.Verify(f => f.Create(arguments), Times.Never);
        }
    }
}
