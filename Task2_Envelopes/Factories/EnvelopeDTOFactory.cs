using Task2_Envelopes.DTOModels;

namespace Task2_Envelopes.Factories
{
    public class EnvelopeDTOFactory : IEnvelopeDTOFactory
    {
        public EnvelopeDTO Create(string height, string width)
        {
            return new EnvelopeDTO(height, width);
        }
    }
}
