using Task7_8_Sequence.Models;

namespace Task7_8_Sequence.Providers
{
    public interface IArgumentsProvider
    {
        ISequenceLimit GetLimits(string[] arguments);
    }
}