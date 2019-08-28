using Task2_Envelopes.Models.Interfaces;

namespace Task2_Envelopes.Utils.Interfaces
{
    public interface IParser
    {
        IEnvelope[] GetEnvelopes(string[] args);
    }
}
