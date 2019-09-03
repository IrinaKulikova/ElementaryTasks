using CustomCollections;
using Task4_Parser.Models;

namespace Task4_Parser.Factories.Interfaces
{
    public interface IParseArgumentsFactory
    {
        ParseArguments Create(IArgumentCollection<string> collection);
    }
}
