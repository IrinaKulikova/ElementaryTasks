using CustomCollections;

namespace Task1_Board.Services.Interfaces
{
    public interface IParser
    {
        IArgumentCollection<int> GetValidArgs(string[] arg);
    }
}
