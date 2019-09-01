using Task5_NumberWord.Models;

namespace Task5_NumberWord.Factories.Interfaces
{
    public interface IDigitsFactory
    {
        Digits Create(string number);
    }
}
