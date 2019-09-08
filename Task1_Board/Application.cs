using ApplicationInitializer;
using CustomCollections;
using Logger;
using System;
using Task1_Board.Controllers.Interfaces;
using Task1_Board.Services.Interfaces;

namespace Task1_Board
{
    public class Application : IApplication
    {
        #region private fields

        private readonly IArgumentsValidator _argumentsValidator = null;
        private readonly IControllerDictionary _controllerDictionry = null;
        private readonly ILogger _logger = null;

        #endregion

        public Application(IArgumentsValidator argumentsValidator,
                           IControllerDictionary controllerDictionry,
                           ILogger logger)
        {
            this._argumentsValidator = argumentsValidator;
            this._controllerDictionry = controllerDictionry;
            this._logger = logger;
        }

        public void Start(string[] args)
        {
            IArgumentCollection<int> arguments = new ArgumentCollection<int>();
            _argumentsValidator.IsValidInputArguments(args, arguments);
            IController controller = null;

            try
            {
                controller = _controllerDictionry.GetController(arguments);
            }
            catch (ArgumentNullException ex)
            {
                _logger.Error(ex);
                controller = _controllerDictionry.GetInvalidArgumentsController(arguments);
            }

            controller.Show();
        }
    }
}