using System;
using Task1_Board.Controllers.Interfaces;
using Task1_Board.Services;
using Task1_Board.Services.Interfaces;
using Task1_Board.Utils;
using Task1_Board.Utils.Interfaces;

namespace Task1_Board
{
    public class Application
    {
        IParser Parser { get; set; }
        IRouter Router { get; set; }

        public Application()
        {
            Parser = new Parser();
            Router = new Router();
        }

        public Application(IParser parser, IRouter router)
        {
            Parser = parser;
            Router = router;
        }

        public void Start(string[] args)
        {
            int[] validArgs = null;
            Controller controller = null;

            try
            {
                validArgs = Parser.GetValidArgs(args);
                controller = Router.GetController(validArgs);
            }
            catch (FormatException ex)
            {
                controller = Router.GetErrorController(ex);
            }
            catch (ArgumentException ex)
            {
                controller = Router.GetErrorController(ex);
            }
            catch (OverflowException ex)
            {
                controller = Router.GetErrorController(ex);
            }

            controller.Show();
        }
    }
}