using Task2_Envelopes.Enums;

namespace Task2_Envelopes.ConsoleUI
{
    public interface UI
    {
        void WriteResult(ResultCompare result);

        string[] GetParametersEnvelopes();

        AnswerReader ReadAnswerContinue();
    }
}
