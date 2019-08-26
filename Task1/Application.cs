using System;
using Task1.Controllers.Interfaces;
using Task1.Services;
using Task1.Services.Interfaces;
using Task1.Utils;
using Task1.Utils.Interfaces;

namespace Task1
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
            IController controller = null;
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