using CustomCollections;

namespace Task1_Board.Services.Interfaces
{
    public interface IArgumentsValidator
    {
        bool IsValidInputArguments(string[] arg, IArgumentCollection<int> argumets);
    }
}
