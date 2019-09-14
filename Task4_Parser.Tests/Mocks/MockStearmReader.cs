using System;
using System.IO;
using System.Text;

namespace Task4_Parser.Tests
{
    public class MockStearmReader : IDisposable
    {
        private readonly MemoryStream _outMemoryStream;
        private readonly StreamReader _streamReader;

        protected string text = @"«Neque porro quisquam est, sit \n
                          qui dolorem ipsum quia dolor \n
                          sit amet, consectetur, adipisci velit, \n
                          sed quia non numquam eius modi tempora \n
                          incidunt ut labore et dolore sit \n
                          magnam aliquam quaerat voluptatem.»";

        public StreamReader StreamReader { get => _streamReader; }
        
        public MockStearmReader()
        {
            _outMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(text));
            _streamReader = new StreamReader(_outMemoryStream);
        }
        
        public virtual void Dispose()
        {
            if (_streamReader != null)
            {
                _streamReader.Close();
            }

            if (_outMemoryStream != null)
            {
                _outMemoryStream.Close();
            }
        }
    }
}
