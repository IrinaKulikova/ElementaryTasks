using Task1_Board.Controllers;

namespace Task1_Board.Services.Interfaces
{
    public interface IRouter
    {
        Controller GetController(int[] args);
        Controller GetErrorController();
    }
}
