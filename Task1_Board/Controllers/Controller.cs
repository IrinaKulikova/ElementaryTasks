using Task1_Board.Controllers.Interfaces;
using Task1_Board.Models;
using Task1_Board.Views.BaseView;

namespace Task1_Board.Controllers
{
    public class Controller : IController
    {
        public ConsoleView View { get; private set; }

        public IModel Model { get; private set; }

        public Controller(ConsoleView view, IModel model)
        {
            View = view;
            Model = model;
        }

        public virtual void Show()
        {
            View.Display(Model);
        }
    }
}
