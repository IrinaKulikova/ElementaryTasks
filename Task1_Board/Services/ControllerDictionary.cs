using System;
using Task1_Board.Controllers;
using Task1_Board.Enums;
using Task1_Board.Models;
using Task1_Board.Services.Interfaces;
using Task1_Board.Views;
using Task1_Board.Factories;
using CustomCollections;
using Task1_Board.Controllers.Interfaces;
using Logger;
using System.Collections.Generic;

namespace Task1_Board.Services
{
    public class ControllerDictionary : IControllerDictionary
    {
        #region private fields

        private readonly IBoardFactory _boardFactory;
        private readonly ILogger _logger;
        private readonly IDictionary<CountArgument, Func<IArgumentCollection<int>, IController>> _dictionary;

        #endregion

        #region ctor

        public ControllerDictionary(IBoardFactory boardFactory, ILogger logger)
        {
            _boardFactory = boardFactory;
            _logger = logger;
            _dictionary = new Dictionary<CountArgument, Func<IArgumentCollection<int>, IController>>();

            Init();
        }

        #endregion

        private void Init()
        {
            _dictionary.Add(CountArgument.Zero, GetInstractionController);
            _dictionary.Add(CountArgument.Necessary, GetBoardController);
            _dictionary.Add(CountArgument.Invalid, GetInvalidArgumentsController);
        }

        public IController GetBoardController(IArgumentCollection<int> arguments)
        {
            var model = _boardFactory.Create(arguments[0], arguments[1]);
            var view = new BoardView(ConsoleColor.White);

            return new Controller(view, model);
        }

        public IController GetInstractionController(IArgumentCollection<int> arguments)
        {
            var model = new Instruction();
            var view = new InstructionView(ConsoleColor.Green);

            return new Controller(view, model);
        }

        public IController GetInvalidArgumentsController(IArgumentCollection<int> arguments)
        {
            var model = new InvalidArguments();
            var view = new InvalidArgumentsView(ConsoleColor.Red);

            return new Controller(view, model);
        }

        public IController GetController(IArgumentCollection<int> arguments)
        {
            CountArgument countArgument = CountArgument.Invalid;

            if (Enum.IsDefined(typeof(CountArgument), arguments.Count))
            {
                countArgument = (CountArgument)arguments.Count;
            }

            Func<IArgumentCollection<int>, IController> function = null;
            bool containsFunction = _dictionary.TryGetValue(countArgument, out function);

            if (containsFunction)
            {
                return function(arguments);
            }

            string message = "Func<IArgumentCollection<int>,IController> is not presented!";

            _logger.Error(message);

            throw new ArgumentNullException(message);
        }
    }
}