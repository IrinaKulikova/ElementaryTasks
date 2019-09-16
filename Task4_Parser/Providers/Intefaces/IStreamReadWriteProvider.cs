using System.IO;

namespace Task4_Parser.Providers.Interfaces
{
    public interface IStreamReadWriteProvider : IStreamReaderProvider
    {
        StreamWriter StreamWriter { get; }
    }
}
