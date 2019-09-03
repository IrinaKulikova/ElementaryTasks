using Task4_Parser.Models;

namespace Task4_Parser.Services.Interfaces
{
    public interface IParser
    {
        int FindText(ParseArguments parseArguments);
    }
}