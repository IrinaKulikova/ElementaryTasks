using Task2_Envelopes.DTOModels;

namespace Task2_Envelopes.Factories
{
    public class FactoryEnvelopeDTO : IFactoryEnvelopeDTO
    {
        public EnvelopeDTO Create(string height, string width)
        {
            return new EnvelopeDTO(height, width);
        }
    }
}
