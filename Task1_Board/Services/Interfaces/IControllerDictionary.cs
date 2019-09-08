using CustomCollections;
using Task1_Board.Controllers.Interfaces;

namespace Task1_Board.Services.Interfaces
{
    public interface IControllerDictionary
    {
        IController GetController(IArgumentCollection<int> args);
        IController GetInvalidArgumentsController(IArgumentCollection<int> args);
    }
}
