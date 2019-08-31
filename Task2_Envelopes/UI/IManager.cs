using Task2_Envelopes.DTOModels;
using Task2_Envelopes.Enums;

namespace Task2_Envelopes.UI
{
    public interface IManager
    {
        void WriteResult(ResultEnvelopeCompare result);
        EnvelopeDTO GetParametersEnvelopes();
        Answer ReadAnswerContinue();
        void ShowInstruction();
        void ShowError(EnvelopeDTO envelopeDTO);
    }
}
