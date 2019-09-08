using Task8_Fibonacci.Models;

namespace Task8_Fibonacci.Factories
{
    public interface ISequenceLimitFactory
    {
        ISequenceLimit Create(string[] limits);
    }
}
