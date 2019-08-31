using Task2_Envelopes.DTOModels;
using Task2_Envelopes.Models.Interfaces;

namespace Task2_Envelopes.Containers.interfaces
{
    public interface IEnvelopeContainer
    {
        IEnvelope FirstEnvelope { get; }
        IEnvelope SecondEnvelope { get; }

        void UpdateEnvelopes(string[] args, EnvelopeDTO firstEnvelopeDTO, EnvelopeDTO secondEnvelopeDTO);
    }
}
