using System;
using Task1_Board.Models;
using Task1_Board.Models.Interfaces;
using Task1_Board.Views.BaseView;

namespace Task1_Board.Views
{
    class InvalidArgumentsView : ConsoleView
    {
        public InvalidArgumentsView(ConsoleColor color) : base(color) { }

        public override void Display(IModel model)
        {
            Console.ForegroundColor = Color;

            if ( model is IMessage invalidArgument )
            {
                Console.WriteLine(invalidArgument.Message);
            }

            Console.ReadLine();
        }
    }
}
