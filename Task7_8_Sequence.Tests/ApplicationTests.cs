using Logger;
using Moq;
using Task7_8_Sequence.Models;
using Task7_8_Sequence.Providers;
using Task7_8_Sequence.Sequences;
using Task7_8_Sequence.UI;
using Xunit;

namespace Task7_8_Sequence.Tests
{
    public class ApplicationTests
    {
        [Theory]
        [InlineData("0", "10")]
        public void Application_WithTwoValidArguments_ShouldCallGetLimits
                                 (string minArgument, string maxArgument)
        {
            var arguments = new string[] { minArgument, maxArgument };

            var mockArgumentsProvider = new Mock<IArgumentsProvider>();
            mockArgumentsProvider.Setup(p => p.GetLimits(arguments))
                                 .Returns(It.IsAny<SequenceLimit>());

            var mockLogger = new Mock<ILogger>();
            var mockConsoleManager = new Mock<IManager>();

            var application = new Application(mockArgumentsProvider.Object,
                                              mockLogger.Object,
                                              mockConsoleManager.Object);

            application.Start(arguments);

            mockArgumentsProvider.Verify(p => p.GetLimits(arguments),
                                         Times.Once);
        }


        [Theory]
        [InlineData("5", "55", "80")]
        public void Application_WithInvalidCountArguments_ShouldCallShowInstruction
                                 (params string[] arguments)
        {
            var mockArgumentsProvider = new Mock<IArgumentsProvider>();
            mockArgumentsProvider.Setup(p => p.GetLimits(arguments))
                                 .Returns(() => null);

            var mockLogger = new Mock<ILogger>();
            var mockConsoleManager = new Mock<IManager>();

            mockConsoleManager.Setup(m => m.ShowInstruction());

            var application = new Application(mockArgumentsProvider.Object,
                                              mockLogger.Object,
                                              mockConsoleManager.Object);

            application.Start(arguments);

            mockConsoleManager.Verify(m => m.ShowInstruction(),
                                      Times.Between(0, 1, Range.Inclusive));
        }


        [Fact]
        public void Application_WithOutArguments_ShouldCallShowInstruction()
        {
            var mockArgumentsProvider = new Mock<IArgumentsProvider>();

            var mockLogger = new Mock<ILogger>();

            var mockConsoleManager = new Mock<IManager>();
            mockConsoleManager.Setup(m => m.ShowInstruction());

            var application = new Application(mockArgumentsProvider.Object,
                                              mockLogger.Object,
                                              mockConsoleManager.Object);

            application.Start(null);

            mockConsoleManager.Verify(m => m.ShowInstruction(),
                                      Times.Between(0, 1, Range.Inclusive));
        }

        [Theory]
        [InlineData("5", "55", 5, 55)]
        public void Application_WithTwoValidArguments_ShouldCallShowResult
                                 (string minArgument, string maxArgument,
                                  int min, int max)
        {
            var arguments = new string[] { minArgument, maxArgument };
            var sequence = new FibonacciSequence(new SequenceLimit(min, max));

            var mockArgumentsProvider = new Mock<IArgumentsProvider>();
           
            var mockLogger = new Mock<ILogger>();
            
            var mockConsoleManager = new Mock<IManager>();

            mockConsoleManager.Setup(m => m.ShowResult(sequence));

            var application = new Application(mockArgumentsProvider.Object,
                                              mockLogger.Object,
                                              mockConsoleManager.Object);

            application.Start(arguments);

            mockConsoleManager.Verify(m => m.ShowResult(sequence),
                                      Times.Between(0, 1, Range.Inclusive));
        }
    }
}