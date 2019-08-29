using System;
using Task1_Board.Controllers;
using Task1_Board.Enums;
using Task1_Board.Models;
using Task1_Board.Services.Interfaces;
using Task1_Board.Views;
using Task1_Board.Views.BaseView;
using Task1.Factories;

namespace Task1_Board.Services
{
    public class Router : IRouter
    {
        IBoardFactory BoardFactory { get; set; }

        public Router(IBoardFactory boardFactory)
        {
            BoardFactory = boardFactory;
        }

        public Controller GetController(int[] args)
        {
            Controller controller = null;
            ConsoleView view = null;
            IModel model = null;

            switch ((CountArgument)args.Length)
            {
                case CountArgument.Zero:
                    model = new Instruction();
                    view = new InstructionView(ConsoleColor.Green, model);
                    controller = new InstructionController(view, model);
                    break;

                case CountArgument.Necessary:
                    model = BoardFactory.Create(args[0], args[1]);
                    view = new BoardView(ConsoleColor.White, model);
                    controller = new BoardController(view, model);
                    break;

                default:
                    controller = GetErrorController();
                    break;

            }

            return controller;
        }

        public Controller GetErrorController()
        {
            var model = new InvalidArguments();
            var view = new InvalidArgumentsView(ConsoleColor.Red, model);

            return new InvalidArgumentsController(view, model);
        }
    }
}