using Task5_NumberWord.ExtentionsMethods;
using Task5_NumberWord.Factories.Interfaces;
using Task5_NumberWord.Models;

namespace Task5_NumberWord.Factories
{
    public class NumberPartFactory : INumberPartFactory
    {
        public NumberPart Create(string numberPart)
        {
            int necessaryLength = 3;
            var argsNumbers = new string[necessaryLength];
            argsNumbers.Populate("0");

            for (int i = numberPart.Length - 1; i >= 0; i--)
            {
                argsNumbers[i] = numberPart[i].ToString();
            }

            return new NumberPart(argsNumbers[0], argsNumbers[1], argsNumbers[2]);
        }
    }
}
