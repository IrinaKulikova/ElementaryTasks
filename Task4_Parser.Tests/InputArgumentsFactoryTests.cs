using Task4_Parser.Enums;
using Task4_Parser.Tests.FixtureClasses;
using Xunit;

namespace Task4_Parser.Tests
{
    public class InputArgumentsFactoryTests : IClassFixture<InputArgumentsFactoryFixture>
    {
        private InputArgumentsFactoryFixture _argumentsFactory;

        public InputArgumentsFactoryTests(InputArgumentsFactoryFixture argumentsFactory)
        {
            _argumentsFactory = argumentsFactory;
        }

        [Theory]
        [InlineData("path", "text")]
        public void InputArgumentsFactory_WithTwoArguments_ShouldRetunedNewText
                                                            (params string[] arguments)
        {            
            var inputsArguments = _argumentsFactory.
                                  InputArgumentsFactory.Create(arguments);

            Assert.Null(inputsArguments.NewText);
        }


        [Theory]
        [InlineData("path", "text")]
        public void InputArgumentsFactory_WithTwoArguments_ShouldRetunedLength
            (params string[] arguments)
        {
            var inputsArguments = _argumentsFactory.
                                  InputArgumentsFactory.Create(arguments);

            Assert.Equal(ValidArgumentsLength.FileSearch,
                          inputsArguments.ArgumentsLength);
        }

        [Theory]
        [InlineData("path", "text")]
        public void InputArgumentsFactory_WithTwoArguments_ShouldRetunedSearchText
           (params string[] arguments)
        {
            var inputsArguments = _argumentsFactory.
                                  InputArgumentsFactory.Create(arguments);

            var searchText = arguments[1];

            Assert.Equal(searchText, inputsArguments.SearchText);
        }

        [Theory]
        [InlineData("path", "text")]
        public void InputArgumentsFactory_WithTwoArguments_ShouldRetunedFilePath
         (params string[] arguments)
        {
            var inputsArguments = _argumentsFactory.
                                  InputArgumentsFactory.Create(arguments);

            var filePath = arguments[0];

            Assert.Equal(filePath, inputsArguments.FilePath);
        }

        [Theory]
        [InlineData("path", "text", "new text")]
        public void InputArgumentsFactory_WithThreeArguments_ShouldRetunedFilePath
                                            (params string[] arguments)
        {
            var inputsArguments = _argumentsFactory.
                                  InputArgumentsFactory.Create(arguments);

            var filePath = arguments[0];

            Assert.Equal(filePath, inputsArguments.FilePath);
        }


        [Theory]
        [InlineData("path", "text", "new text")]
        public void InputArgumentsFactory_WithThreeArguments_ShouldRetunedSearchText
                                       (params string[] arguments)
        {
            var inputsArguments = _argumentsFactory.
                                  InputArgumentsFactory.Create(arguments);

            var searchText = arguments[1];

            Assert.Equal(searchText, inputsArguments.SearchText);
        }

        [Theory]
        [InlineData("path", "text", "new text")]
        public void InputArgumentsFactory_WithThreeArguments_ShouldRetunedNewText
                                       (params string[] arguments)
        {
            var inputsArguments = _argumentsFactory.
                                  InputArgumentsFactory.Create(arguments);

            var newText = arguments[2];

            Assert.Equal(newText, inputsArguments.NewText);
        }


        [Theory]
        [InlineData("path", "text", "new text")]
        public void InputArgumentsFactory_WithThreeArguments_ShouldRetunedLength
                                     (params string[] arguments)
        {
            var inputsArguments = _argumentsFactory.
                                  InputArgumentsFactory.Create(arguments);

            Assert.Equal(ValidArgumentsLength.FileSearchReplace,
                          inputsArguments.ArgumentsLength);
        }
    }
}
