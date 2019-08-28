using Task2_Envelopes.Models;

namespace Task2_Envelopes.Utils.Interfaces
{
    public interface IParser
    {
        Envelope GetEnvelope(string hegth, string width);
    }
}
