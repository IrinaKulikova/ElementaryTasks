using Task2_Envelopes.DTOModels;
using Task2_Envelopes.Models.Interfaces;
using Task2_Envelopes.Services;

namespace Task2_Envelopes
{
    public interface IEnvelopeMapper
    {
        event Error ShowError;
        IEnvelope Map(EnvelopeDTO envelopeDTO);
    }
}