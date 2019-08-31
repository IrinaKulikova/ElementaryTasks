using Task2_Envelopes.DTOModels;

namespace Task2_Envelopes.Factories
{
    public interface IFactoryEnvelopeDTO
    {
        EnvelopeDTO Create(string height, string width);
    }
}
