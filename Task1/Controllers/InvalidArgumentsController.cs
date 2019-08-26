using Task1.Controllers.Interfaces;
using Task1.Models;
using Task1.Views;

namespace Task1.Controllers
{
    public class InvalidArgumentsController: IController 
    {
        private ConsoleView View { get; set; }
        private IModel Model { get; set; }

        public InvalidArgumentsController(ConsoleView view, IModel model)
        {
            View = view;
            Model = model;
        }

        public void Show()
        {
            View.Display(Model);
        }
    }
}
