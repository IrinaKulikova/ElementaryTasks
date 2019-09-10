using Logger;
using Moq;
using Task4_Parser.Enums;
using Task4_Parser.Factories;
using Task4_Parser.Models;
using Xunit;

namespace Task4_Parser.Tests
{
    public class InputArgumentsFactory_Tests
    {
        [Theory]
        [InlineData("path", "text")]
        public void Create_TwoArguments_Success(params string[] arguments)
        {
            var mockLogger = new Mock<ILogger>();

            var factory = new InputArgumentsFactory(mockLogger.Object);

            var inputsArguments = factory.Create(arguments);

            Assert.IsType<InputArguments>(inputsArguments);
            Assert.Equal(arguments[0], inputsArguments.FilePath);
            Assert.Equal(arguments[1], inputsArguments.SearchText);
            Assert.Null(inputsArguments.NewText);
            Assert.Equal(ValidArgumentsLength.FileSearch,
                          inputsArguments.ArgumentsLength);
        }

        [Theory]
        [InlineData("path", "text", "new text")]
        public void Create_ThreeArguments_Success(params string[] arguments)
        {
            var mockLogger = new Mock<ILogger>();

            var factory = new InputArgumentsFactory(mockLogger.Object);

            var inputsArguments = factory.Create(arguments);

            Assert.IsType<InputArguments>(inputsArguments);
            Assert.Equal(arguments[0], inputsArguments.FilePath);
            Assert.Equal(arguments[1], inputsArguments.SearchText);
            Assert.Equal(arguments[2],inputsArguments.NewText);
            Assert.Equal(ValidArgumentsLength.FileSearchReplace,
                          inputsArguments.ArgumentsLength);
        }
    }
}
