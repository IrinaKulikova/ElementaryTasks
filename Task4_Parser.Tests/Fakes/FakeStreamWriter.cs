using System;
using System.IO;
using System.Text;

namespace Task4_Parser.Tests
{
    public class FakeStreamWriter : FakeStearmReader, IDisposable
    {
        MemoryStream _inMemoryStream;
        StreamWriter _streamWriter;

        public StreamWriter StreamWriter { get => _streamWriter; }
        public MemoryStream MemoryStream { get => _inMemoryStream; }

        public string ReplacedText { get => _replacedText; }

        private string _replacedText = @"«Neque porro quisquam est, * \n
                          qui dolorem ipsum quia dolor \n
                          * amet, consectetur, adipisci velit, \n
                          sed quia non numquam eius modi tempora \n
                          incidunt ut labore et dolore * \n
                          magnam aliquam quaerat voluptatem.»";

        public FakeStreamWriter() : base()
        {
            _inMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(_replacedText));
            _streamWriter = new StreamWriter(_inMemoryStream);
        }

        public override void Dispose()
        {
            if (_inMemoryStream != null)
            {
                _inMemoryStream.Close();
            }

            base.Dispose();

        }
    }
}
