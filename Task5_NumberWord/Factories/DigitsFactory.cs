using Task5_NumberWord.ExtensionsMethods;
using Task5_NumberWord.Factories.Interfaces;
using Task5_NumberWord.Models;

namespace Task5_NumberWord.Factories
{
    public class DigitsFactory : IDigitsFactory
    {
        public Digits Create(string numberPart)
        {
            int necessaryLength = 3;
            var argsNumbers = new string[necessaryLength];
            argsNumbers.Populate("0");

            for (int i = numberPart.Length - 1, j = necessaryLength -1; i >= 0; i--, j--)
            {
                argsNumbers[j] = numberPart[i].ToString();
            }

            return new Digits(argsNumbers[0], argsNumbers[1], argsNumbers[2]);
        }
    }
}
