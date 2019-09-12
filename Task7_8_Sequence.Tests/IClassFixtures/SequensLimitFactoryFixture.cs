using Logger;
using Moq;
using Task7_8_Sequence.Factories;

namespace Task7_8_Sequence.Tests.IClassFixtures
{
    public class SequensLimitFactoryFixture
    {
        private SequenceLimitFactory _sequenceLimitFactory;

        public ISequenceLimitFactory SequenceLimitFactory
        {
            get => _sequenceLimitFactory;
        }

        public SequensLimitFactoryFixture()
        {
            var mockLogger = new Mock<ILogger>();

            _sequenceLimitFactory = new SequenceLimitFactory(mockLogger.Object);
        }
    }
}
