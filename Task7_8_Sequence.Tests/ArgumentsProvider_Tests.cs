using Logger;
using Moq;
using Task7_8_Sequence.Factories;
using Task7_8_Sequence.Models;
using Task7_8_Sequence.Providers;
using Task7_8_Sequence.Validators;
using Xunit;

namespace Task7_8_Sequence.Tests
{
    public class ArgumentsProvider_Tests
    {
        [Fact]
        public void GetLimits_Success()
        {
            var arguments = new string[] { "5", "8" };

            var mockValidator = new Mock<IArgumentsValidator>();
            mockValidator.Setup(v => v.HasValidArguments(arguments)).Returns(It.IsAny<bool>());

            var mockSequenceFactory = new Mock<ISequenceLimitFactory>();
            mockSequenceFactory.Setup(f => f.Create(arguments)).Returns(It.IsAny<ISequenceLimit>());

            var mockLogger = new Mock<ILogger>();

            var provider = new ArgumentsProvider(mockValidator.Object,
                                                 mockSequenceFactory.Object,
                                                 mockLogger.Object);

            provider.GetLimits(arguments);

            mockValidator.Verify(v => v.HasValidArguments(arguments), Times.Once);
            mockSequenceFactory.Verify(f => f.Create(arguments), Times.Between(0, 1, Range.Inclusive));
        }
    }
}
