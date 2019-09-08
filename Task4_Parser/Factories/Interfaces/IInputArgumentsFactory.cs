using Task4_Parser.Models;

namespace Task4_Parser.Factories.Interfaces
{
    public interface IInputArgumentsFactory
    {
        IInputArguments Create(string[] arguments);
    }
}
