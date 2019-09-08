using Task4_Parser.Models;

namespace Task4_Parser.Providers
{
    public interface IArgumentsProvider
    {
        IInputArguments GetArguments(string[] arguments);
            
    }
}
