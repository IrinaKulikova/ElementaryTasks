using System;
using Task2_Envelopes.DTOModels;
using Task2_Envelopes.Enums;

namespace Task2_Envelopes.UI
{
    public class ConsoleManager : IManager
    {
        public EnvelopeDTO GetParametersEnvelopes()
        {
            Console.Write("Height: ");
            var height = Console.ReadLine();
            Console.Write("Width: ");
            var width = Console.ReadLine();

            return new EnvelopeDTO(height, width);
        }

        public Answer ReadAnswerContinue()
        {
            throw new NotImplementedException();
        }

        public void ShowError()
        {
            throw new NotImplementedException();
        }

        public void ShowInstruction()
        {
            //throw new NotImplementedException();
        }

        public void WriteResult(ResultEnvelopeCompare result)
        {
            throw new NotImplementedException();
        }
    }
}
