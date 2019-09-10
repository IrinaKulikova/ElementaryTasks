using System;
using System.IO;
using System.Text;
using Task4_Parser.Services;
using Xunit;

namespace Task4_Parser.Tests
{
    public class ParserReplacer_Tests : IDisposable
    {
        MemoryStream outStream;
        StreamReader streamReader;

        MemoryStream inStream;
        StreamWriter streamWriter;

        public ParserReplacer_Tests()
        {
            InitStreamReader();
            InitStreamWriter();
        }


        [Theory]
        [InlineData("sit", "*", InputData)]
        public void Replace_Success(string search, string newText, string expected)
        {
            var parser = new ParserReplacer();

            parser.Replace(streamWriter, streamReader, search, newText);

            var newStraemText = Encoding.UTF8.GetString(inStream.ToArray());

            Assert.Equal(newStraemText, expected);
        }

        public const string InputData = @"«Neque porro quisquam est, * \n
                          qui dolorem ipsum quia dolor \n
                          * amet, consectetur, adipisci velit, \n
                          sed quia non numquam eius modi tempora \n
                          incidunt ut labore et dolore * \n
                          magnam aliquam quaerat voluptatem.»";

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


        public void InitStreamWriter()
        {
            inStream = new MemoryStream(Encoding.UTF8.GetBytes(InputData));
            streamWriter = new StreamWriter(outStream);
        }

        public void Dispose()
        {
            //streamWriter.Close();
            inStream.Close();
            streamReader.Close();
            outStream.Close();
        }
    }
}
