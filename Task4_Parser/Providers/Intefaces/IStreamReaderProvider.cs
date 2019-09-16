using System.IO;

namespace Task4_Parser.Providers.Interfaces
{
    public interface IStreamReaderProvider
    {
        StreamReader StreamReader { get; }
    }
}
