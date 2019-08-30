using Task1_Board.Models;
using Task1_Board.Views.BaseView;

namespace Task1_Board.Controllers
{
    public class InstructionController : Controller
    {
        public InstructionController(ConsoleView view, IModel model) : base(view, model) { }
    }
}
