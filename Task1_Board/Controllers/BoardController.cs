using Task1_Board.Controllers.Interfaces;
using Task1_Board.Models;
using Task1_Board.Views.BaseView;

namespace Task1_Board.Controllers
{
    public class BoardController : Controller
    {
        public BoardController(ConsoleView view, IModel model) : base(view, model) { }
    }
}
