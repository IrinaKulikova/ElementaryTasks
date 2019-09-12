using System.Text;
using Task4_Parser.Services;
using Xunit;

namespace Task4_Parser.Tests
{
    public class ParserReplacer_Tests : IClassFixture<FakeStreamWriter>
    {
        private FakeStreamWriter _fakeStreamWriter;

        public ParserReplacer_Tests(FakeStreamWriter fakeStreamWriter)
        {
            _fakeStreamWriter = fakeStreamWriter;
        }

        [Theory]
        [InlineData("sit", "*")]
        public void test_Replace_TakesValidArguments_ShouldRetunsTrue(string search, string newText)
        {
            var parser = new ParserReplacer();

            parser.Replace(_fakeStreamWriter.StreamWriter,
                           _fakeStreamWriter.StreamReader,
                           search, newText);

            _fakeStreamWriter.MemoryStream.Flush();

            var newStraemText = Encoding.UTF8.GetString(_fakeStreamWriter.MemoryStream.ToArray());

            Assert.Equal(newStraemText, _fakeStreamWriter.ReplacedText);
        }
    }
}
