using Task8_Fibonacci.Models;

namespace Task8_Fibonacci.Providers
{
    public interface IArgumentsProvider
    {
        ISequenceLimit GetLimits(string[] arguments);
    }
}