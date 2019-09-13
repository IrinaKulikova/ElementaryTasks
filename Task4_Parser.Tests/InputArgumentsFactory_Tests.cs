using Logger;
using Task4_Parser.Enums;
using Task4_Parser.Tests.IClassFixtures;
using Xunit;

namespace Task4_Parser.Tests
{
    public class InputArgumentsFactory_Tests : IClassFixture<InputArgumentsFactoryFixture>
    {
        private InputArgumentsFactoryFixture _argumentsFactory;

        public InputArgumentsFactory_Tests(InputArgumentsFactoryFixture argumentsFactory)
        {
            _argumentsFactory = argumentsFactory;
        }

        [Theory]
        [InlineData("path", "text")]
        public void Create_TwoArguments_VerifyRetunedInstanceNewText
                                                (params string[] arguments)
        {            
            var inputsArguments = _argumentsFactory.
                                  InputArgumentsFactory.Create(arguments);

            Assert.Null(inputsArguments.NewText);
        }


        [Theory]
        [InlineData("path", "text")]
        public void Create_TwoArguments_VerifyRetunedInstanceLength
            (params string[] arguments)
        {
            var inputsArguments = _argumentsFactory.
                                  InputArgumentsFactory.Create(arguments);

            Assert.Equal(ValidArgumentsLength.FileSearch,
                          inputsArguments.ArgumentsLength);
        }

        [Theory]
        [InlineData("path", "text")]
        public void Create_TwoArguments_VerifyRetunedInstanceSearchText
           (params string[] arguments)
        {
            var inputsArguments = _argumentsFactory.
                                  InputArgumentsFactory.Create(arguments);

            Assert.Equal(arguments[1], inputsArguments.SearchText);
        }

        [Theory]
        [InlineData("path", "text")]
        public void Create_TwoArguments_VerifyRetunedInstanceFilePath
         (params string[] arguments)
        {
            var inputsArguments = _argumentsFactory.
                                  InputArgumentsFactory.Create(arguments);

            Assert.Equal(arguments[0], inputsArguments.FilePath);
        }

        [Theory]
        [InlineData("path", "text", "new text")]
        public void Create_ThreeArguments_VerifyRetunedInstanceFilePath
                                            (params string[] arguments)
        {
            var inputsArguments = _argumentsFactory.
                                  InputArgumentsFactory.Create(arguments);

            Assert.Equal(arguments[0], inputsArguments.FilePath);
        }


        [Theory]
        [InlineData("path", "text", "new text")]
        public void Create_ThreeArguments_VerifyRetunedInstanceSearchText
                                       (params string[] arguments)
        {
            var inputsArguments = _argumentsFactory.
                                  InputArgumentsFactory.Create(arguments);

            Assert.Equal(arguments[1], inputsArguments.SearchText);
        }

        [Theory]
        [InlineData("path", "text", "new text")]
        public void Create_ThreeArguments_VerifyRetunedInstanceNewText
                                       (params string[] arguments)
        {
            var inputsArguments = _argumentsFactory.
                                  InputArgumentsFactory.Create(arguments);

            Assert.Equal(arguments[2], inputsArguments.NewText);
        }


        [Theory]
        [InlineData("path", "text", "new text")]
        public void Create_ThreeArguments_VerifyRetunedInstanceLength
                                     (params string[] arguments)
        {
            var inputsArguments = _argumentsFactory.
                                  InputArgumentsFactory.Create(arguments);

            Assert.Equal(ValidArgumentsLength.FileSearchReplace,
                          inputsArguments.ArgumentsLength);
        }
    }
}
