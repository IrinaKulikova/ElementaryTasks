using System;
using Task1.Utils;
using Task1.Utils.Interfaces;
using Task1_Board.Controllers;
using Task1_Board.Controllers.Interfaces;
using Task1_Board.Enums;
using Task1_Board.Models;
using Task1_Board.Services.Interfaces;
using Task1_Board.Views;
using Task1_Board.Views.BaseView;

namespace Task1_Board.Services
{
    public class Router : IRouter
    {
        IConverterCountArgument Converter { get; set; }

        public Router()
        {
            Converter = new ConverterCountArguments();
        }

        public Router(IConverterCountArgument converter)
        {
            Converter = converter;
        }

        public Controller GetController(int[] args)
        {
            Controller controller = null;
            ConsoleView view = null;
            IModel model = null;

            var count = Converter.GetValue(args?.Length);

            switch (count)
            {
                case CountArgument.Zero:
                    view = new InstractionView(ConsoleColor.Green);
                    model = new Instraction();
                    controller = new InstractionController(view, model);
                    break;

                case CountArgument.Necessary:
                    view = new BoardView(ConsoleColor.White);
                    model = new Board(args[0], args[1]);
                    controller = new BoardController(view, model);
                    break;

                default:
                    view = new InvalidArgumentsView(ConsoleColor.Red);
                    model = new InvalidArguments();
                    controller = new InvalidArgumentsController(view, model);
                    break;
            }

            return controller;
        }

        public Controller GetErrorController(Exception ex)
        {
            var view = new InvalidArgumentsView(ConsoleColor.Red);
            var model = new InvalidArguments(ex);

            return new InvalidArgumentsController(view, model);
        }
    }
}