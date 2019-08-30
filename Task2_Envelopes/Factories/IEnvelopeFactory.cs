using Task2_Envelopes.Models.Interfaces;

namespace Task2_Envelopes.Factories
{
    public interface IEnvelopeFactory
    {
        IEnvelope Create(float heigth, float width);
    }
}
