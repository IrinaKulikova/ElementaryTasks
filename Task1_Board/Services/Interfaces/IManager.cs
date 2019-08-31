using CustomCollections;
using Task1_Board.Controllers.Interfaces;

namespace Task1_Board.Services.Interfaces
{
    public interface IManager
    {
        IController Routing(IArgumentCollection<int> args);
        IController GetErrorController();
    }
}
