using System.IO;

namespace Task4_Parser.Services.Interfaces
{
    public interface IFileStreamReplacer : IFileStreamCounter
    {
        StreamWriter StreamWriter { get; }
    }
}
