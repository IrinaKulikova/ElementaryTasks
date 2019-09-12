﻿using Logger;
using Moq;
using Task4_Parser.Factories.Interfaces;
using Task4_Parser.Models;
using Task4_Parser.Providers;
using Task4_Parser.Validators;
using Xunit;

namespace Task4_Parser.Tests
{
    public class ArgumentsProvider_Tests
    {
        [Theory]
        [InlineData(true, new string[] { "..//alice.txt", "text" })]
        [InlineData(true, new string[] { "..//alice.txt", "text", "new t" })]
        public void test_GetArguments_TakeValidArgs_VerifyCallMethods
                                                (bool isValid, string[] args)
        {
            var mockLogger = new Mock<ILogger>();

            var mockArgumentsValidator = new Mock<IArgumentsValidator>();

            mockArgumentsValidator.Setup(v => v.HasValidArguments(args))
                                  .Returns(isValid);

            var mockInputArgumentsFactory = new Mock<IInputArgumentsFactory>();

            mockInputArgumentsFactory.Setup(v => v.Create(args))
                                  .Returns(It.IsAny<IInputArguments>());

            var argumentsProvider = new ArgumentsProvider
                                        (mockArgumentsValidator.Object,
                                         mockInputArgumentsFactory.Object,
                                         mockLogger.Object);

            argumentsProvider.GetArguments(args);

            mockArgumentsValidator.Verify(v =>
                                   v.HasValidArguments(args),
                                   Times.Once);

            mockInputArgumentsFactory.Verify(f =>
                                   f.Create(args),
                                   Times.Once);

        }


        [Theory]
        [InlineData(false, new string[] { "..//alice.txt", "text" })]
        [InlineData(false, new string[] { "..//alice.txt", "text", "new text" })]
        public void test_GetArguments_InvalidArgs_VerifyCallMethods
                                                    (bool isValid, string[] args)
        {
            var mockLogger = new Mock<ILogger>();

            var mockArgumentsValidator = new Mock<IArgumentsValidator>();

            mockArgumentsValidator.Setup(v => v.HasValidArguments(args))
                                  .Returns(isValid);

            var mockInputArgumentsFactory = new Mock<IInputArgumentsFactory>();

            mockInputArgumentsFactory.Setup(v => v.Create(args))
                                  .Returns(It.IsAny<IInputArguments>());

            var argumentsProvider = new ArgumentsProvider
                                        (mockArgumentsValidator.Object,
                                         mockInputArgumentsFactory.Object,
                                         mockLogger.Object);

            argumentsProvider.GetArguments(args);

            mockArgumentsValidator.Verify(v =>
                                   v.HasValidArguments(args),
                                   Times.Once);

            mockInputArgumentsFactory.Verify(f =>
                                   f.Create(args),
                                   Times.Never);

        }
    }
}
