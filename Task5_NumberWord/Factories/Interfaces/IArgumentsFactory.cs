using Task5_NumberWord.Models;

namespace Task5_NumberWord.Factories.Interfaces
{
    public interface IArgumentsFactory
    {
        Arguments Create(string[] args);
    }
}
