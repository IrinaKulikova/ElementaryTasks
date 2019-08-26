using System;
using Task1.Controllers;
using Task1.Controllers.Interfaces;
using Task1.Enums;
using Task1.Models;
using Task1.Services.Interfaces;
using Task1.Views;

namespace Task1.Services
{
    public class Router : IRouter
    {
        public IController GetController(int[] args)
        {
            IController controller = null;

            switch (args.Length)
            {
                case (int)CountArgument.Zero:
                    controller = new InstractionController(new InstractionView(ConsoleColor.Green), new Instraction());
                    break;

                case (int)CountArgument.Necessary:
                    controller = new BoardController(new BoardView(ConsoleColor.White), new Board(args[0], args[1]));
                    break;

                default:
                    controller = new InvalidArgumentsController(new InvalidArgumentsView(ConsoleColor.Red), new InvalidArguments());
                    break;
            }
            return controller;
        }

        public IController GetErrorController(Exception ex)
        {
            return new InvalidArgumentsController(new InvalidArgumentsView(ConsoleColor.Red), new InvalidArguments(ex));
        }
    }
}