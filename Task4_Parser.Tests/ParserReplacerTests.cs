using System;
using System.Text;
using Task4_Parser.Services;
using Xunit;

namespace Task4_Parser.Tests
{
    public class ParserReplacerTests : IClassFixture<MockStreamWriter>
    {
        private MockStreamWriter _mockStreamWriter;

        public ParserReplacerTests(MockStreamWriter mockStreamWriter)
        {
            _mockStreamWriter = mockStreamWriter;
        }

        [Theory]
        [InlineData("sit", "*")]
        public void ParserReplacer_WithValidArguments_ShouldRetunsTrue(
                                        string search, string newText)
        {
            var parser = new ParserReplacer(_mockStreamWriter.StreamWriter,
                                            _mockStreamWriter.StreamReader);

            parser.Replace(search, newText);

            _mockStreamWriter.MemoryStream.Flush();

            var newStraemText = Encoding.UTF8.GetString(_mockStreamWriter
                                                .MemoryStream.ToArray());

            Assert.Equal(newStraemText, _mockStreamWriter.ReplacedText);
        }


        [Fact]
        public void ParserReplacer_WithStreamsNull_ShouldThrowNullReferenceException()
        {
            var parser = new ParserReplacer(null, null);
            var searchText = "text";
            var newText = "new";

            Assert.Throws<NullReferenceException>(() => parser.Replace(searchText, newText));
        }

        [Fact]
        public void ParserReplacer_WithStreamReaderNull_ShouldThrowNullReferenceException()
        {
            var parser = new ParserReplacer(null, _mockStreamWriter.StreamReader);
            var searchText = "text";
            var newText = "new";

            Assert.Throws<NullReferenceException>(() => parser.Replace(searchText, newText));
        }


        [Fact]
        public void ParserReplacer_WithStreamWriterNull_ShouldThrowNullReferenceException()
        {
            var parser = new ParserReplacer(_mockStreamWriter.StreamWriter, null);
            var searchText = "text";
            var newText = "new";

            Assert.Throws<NullReferenceException>(() =>
                                    parser.Replace(searchText, newText));
        }
    }
}
