using DIResolver;
using Logger;
using System;
using Task1_Board.Controllers.Interfaces;
using Task1_Board.Services.Interfaces;

namespace Task1_Board
{
    public class Application : IApplication
    {
        public IParser Parser { get; private set; }
        public IManager Manager { get; private set; }
        public ILogger Logger { get; private set; }

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