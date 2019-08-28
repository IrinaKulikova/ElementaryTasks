using System;
using Task2_Envelopes.Enums;

namespace Task2_Envelopes.ConsoleUI
{
    public class ConsoleInterface : UI
    {
        public string[] GetParametersEnvelopes()
        {
            //throw new NotImplementedException();
            return new string[] { "5", "6", "6", "5" };
        }

        public void WriteResult(ResultCompare result)
        {
            throw new NotImplementedException();
        }
    }
}
