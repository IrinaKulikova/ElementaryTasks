using DIResolver;
using Logger;
using System;
using Task1_Board.Controllers.Interfaces;
using Task1_Board.Services.Interfaces;

namespace Task1_Board
{
    public class Application : IApplication
    {
        #region private fields

        private readonly IParser Parser = null;
        private readonly IManager Manager = null;
        private readonly ILogger Logger = null;

        #endregion

        public Application(IParser parser, IManager manager, ILogger logger)
        {
            Parser = parser;
            Manager = manager;
            Logger = logger;
        }

        public void Start(string[] args)
        {
            IController controller = null;

            try
            {
                var validArgs = Parser.GetValidArgs(args);
                controller = Manager.Routing(validArgs);
            }
            catch (FormatException ex)
            {
                controller = Manager.GetErrorController();
                Logger.Error(ex);
            }
            catch (ArgumentException ex)
            {
                controller = Manager.GetErrorController();
                Logger.Error(ex);
            }
            catch (OverflowException ex)
            {
                controller = Manager.GetErrorController();
                Logger.Error(ex);
            }

            controller.Show();
        }
    }
}