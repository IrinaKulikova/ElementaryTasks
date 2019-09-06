using System;
using Task1_Board.Controllers;
using Task1_Board.Enums;
using Task1_Board.Models;
using Task1_Board.Services.Interfaces;
using Task1_Board.Views;
using Task1_Board.Views.BaseView;
using Task1_Board.Factories;
using CustomCollections;
using Task1_Board.Controllers.Interfaces;

namespace Task1_Board.Services
{
    public class Manager : IManager
    {
        #region private fields

        private readonly IBoardFactory BoardFactory = null;

        #endregion

        public Manager(IBoardFactory boardFactory)
        {
            BoardFactory = boardFactory;
        }

        public IController Routing(IArgumentCollection<int> args)
        {
            ConsoleView view = null;
            IModel model = null;

            switch ((CountArgument)args.Count)
            {
                case CountArgument.Zero:
                    model = new Instruction();
                    view = new InstructionView(ConsoleColor.Green);
                    break;

                case CountArgument.Necessary:
                    model = BoardFactory.Create(args[0], args[1]);
                    view = new BoardView(ConsoleColor.White);
                    break;

                default:
                    model = new InvalidArguments();
                    view = new InvalidArgumentsView(ConsoleColor.Red);
                    break;
            }

            return new Controller(view, model);
        }

        public IController GetErrorController()
        {
            var model = new InvalidArguments();
            var view = new InvalidArgumentsView(ConsoleColor.Red);

            return new Controller(view, model);
        }
    }
}