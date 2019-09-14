using Logger;
using Moq;
using Task4_Parser.Factories;
using Task4_Parser.Factories.Interfaces;

namespace Task4_Parser.Tests.FixtureClasses
{
    public class InputArgumentsFactoryFixture
    {
        private IInputArgumentsFactory _inputArgumentsFactory;

        public IInputArgumentsFactory InputArgumentsFactory
        {
            get => _inputArgumentsFactory;
        }

        public InputArgumentsFactoryFixture()
        {
            var mockLogger = new Mock<ILogger>();

            _inputArgumentsFactory = new InputArgumentsFactory(mockLogger.Object);
        }
    }
}
