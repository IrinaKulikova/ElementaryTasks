using System;
using System.IO;
using System.Text;
using Task4_Parser.Services;
using Xunit;

namespace Task4_Parser.Tests
{
    public class ParserCounter_Tests : IDisposable
    {
        MemoryStream outStream;
        StreamReader streamReader;

        public ParserCounter_Tests()
        {
            InitStreamReader();
        }

        public void InitStreamReader()
        {
            var text = @"«Neque porro quisquam est, sit \n
                          qui dolorem ipsum quia dolor \n
                          sit amet, consectetur, adipisci velit, \n
                          sed quia non numquam eius modi tempora \n
                          incidunt ut labore et dolore sit \n
                          magnam aliquam quaerat voluptatem.»";

            outStream = new MemoryStream(Encoding.UTF8.GetBytes(text));
            streamReader = new StreamReader(outStream);
        }

        [Theory]
        [InlineData("sit", 3)]
        public void Calculate(string search, int expectedCount)
        {
            var parser = new ParserCounter();

            int countResult = parser.Calculate(streamReader, search);

            Assert.Equal(countResult, expectedCount);
        }

        public void Dispose()
        {
            if (streamReader != null)
            {
                streamReader.Close();
            }

            if (outStream != null)
            {
                outStream.Close();
            }
        }
    }
}
