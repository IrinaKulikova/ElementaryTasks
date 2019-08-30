using Task2_Envelopes.DTOModels;
using Task2_Envelopes.Models.Interfaces;

namespace Task2_Envelopes.Services.Interfaces
{
    public interface IParser
    {
        IEnvelope GetEnvelope(EnvelopeDTO envelopeDTO);
    }
}
