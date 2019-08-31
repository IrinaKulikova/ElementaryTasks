using Task2_Envelopes.DTOModels;

namespace Task2_Envelopes.Factories
{
    public interface IEnvelopeDTOFactory
    {
        EnvelopeDTO Create(string height, string width);
    }
}
