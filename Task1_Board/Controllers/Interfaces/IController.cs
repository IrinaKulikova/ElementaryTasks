using Task1_Board.Models;
using Task1_Board.Views.BaseView;

namespace Task1_Board.Controllers.Interfaces
{
    public interface IController
    {
        ConsoleView View { get; }
        IModel Model { get; }

        void Show();
    }
}
