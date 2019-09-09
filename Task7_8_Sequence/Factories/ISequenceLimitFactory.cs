using Task7_8_Sequence.Models;

namespace Task7_8_Sequence.Factories
{
    public interface ISequenceLimitFactory
    {
        ISequenceLimit Create(string[] limits);
    }
}
