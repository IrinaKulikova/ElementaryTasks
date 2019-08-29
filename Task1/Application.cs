using System;
using Task1.Logger;
using Task1_Board.Controllers;
using Task1_Board.Services.Interfaces;
using Task1_Board.Utils.Interfaces;

namespace Task1_Board
{
    public class Application
    {
        public IParser Parser { get; private set; }
        public IRouter Router { get; private set; }
        public ILogger Logger { get; private set; }

        public Application(IParser parser, IRouter router, ILogger logger)
        {
            Parser = parser;
            Router = router;
            Logger = logger;
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
                controller = Router.GetErrorController();
                Logger.Error(ex);
            }
            catch (ArgumentException ex)
            {
                controller = Router.GetErrorController();
                Logger.Error(ex);
            }
            catch (OverflowException ex)
            {
                controller = Router.GetErrorController();
                Logger.Error(ex);
            }

            controller.Show();
        }
    }
}