using Logger;
using Moq;
using Task7_8_Sequence.Sequences;
using Task7_8_Sequence.Models;
using Task7_8_Sequence.Providers;
using Task7_8_Sequence.UI;
using Xunit;

namespace Task7_8_Sequence.Tests
{
    public class Application_Tests
    {
        [Theory]
        [InlineData("5", "55", 5, 55)]
        public void Start_Success(string minArgument, string maxArgument,
                                  int min, int max)
        {
            var arguments = new string[] { minArgument, maxArgument };
            var sequence = new FibonacciSequence(new SequenceLimit(min, max));

            var mockArgumentsProvider = new Mock<IArgumentsProvider>();
            mockArgumentsProvider.Setup(p => p.GetLimits(arguments))
                                 .Returns(It.IsAny<SequenceLimit>());

            var mockLogger = new Mock<ILogger>();
            mockLogger.Setup(l => l.Error(It.IsAny<string>()));

            var mockConsoleManager = new Mock<IManager>();

            mockConsoleManager.Setup(m => m.ShowInstruction());
            mockConsoleManager.Setup(m => m.ShowResult(sequence));

            var application = new Application(mockArgumentsProvider.Object,
                                              mockLogger.Object,
                                              mockConsoleManager.Object);

            application.Start(arguments);

            mockConsoleManager.Verify(m => m.ShowInstruction(),
                                      Times.Between(0, 1, Range.Inclusive));
            mockConsoleManager.Verify(m => m.ShowResult(sequence),
                                      Times.Between(0, 1, Range.Inclusive));

            mockArgumentsProvider.Verify(p => p.GetLimits(arguments),
                                         Times.Once);

            mockLogger.Verify(l => l.Error(It.IsAny<string>()),
                              Times.Between(0, 1, Range.Inclusive));
        }
    }
}