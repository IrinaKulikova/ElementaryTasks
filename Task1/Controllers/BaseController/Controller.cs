using Task1_Board.Models;
using Task1_Board.Views.BaseView;

namespace Task1_Board.Controllers.Interfaces
{
    public abstract class Controller
    {
        protected ConsoleView View { get; private set; }
        protected IModel Model { get; private set; }

        public Controller() { }

        public Controller(ConsoleView view, IModel model)
        {
            View = view;
            Model = model;
        }

        public virtual void Show() => View.Display(Model);
    }
}
