using Task4_Parser.Services;
using Xunit;

namespace Task4_Parser.Tests
{
    public class ParserCounter_Tests : IClassFixture<FakeStearmReader>
    {
        private FakeStearmReader _fakeStearmReader;

        public ParserCounter_Tests(FakeStearmReader fakeStearmReader)
        {
            _fakeStearmReader = fakeStearmReader;
        }

        [Theory]
        [InlineData("sit", 3)]
        public void Calculate_SetValidArguments_ShouldReturnsTrue
                                            (string search, int expectedCount)
        {
            var parser = new ParserCounter();

            int countResult = parser.Calculate(_fakeStearmReader.StreamReader,
                                               search);

            Assert.Equal(countResult, expectedCount);
        }
    }
}
