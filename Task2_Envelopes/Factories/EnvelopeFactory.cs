using Task2_Envelopes.Models;
using Task2_Envelopes.Models.Interfaces;

namespace Task2_Envelopes.Factories
{
    public class EnvelopeFactory : IEnvelopeFactory
    {
        public IEnvelope Create(float heigth, float width)
        {
            var envelope = new Envelope(heigth, width);
            return envelope;
        }
    }
}
