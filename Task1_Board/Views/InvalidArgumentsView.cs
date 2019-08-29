using System;
using Task1_Board.Models;
using Task1_Board.Models.Interfaces;
using Task1_Board.Views.BaseView;

namespace Task1_Board.Views
{
    class InvalidArgumentsView : ConsoleView
    {
        public InvalidArgumentsView(ConsoleColor color, IModel model) : base(color, model) { }

        public override void Display()
        {
            Console.ForegroundColor = Color;

            if ( Model is IMessage invalidArgument )
            {
                Console.WriteLine(invalidArgument.Message);
            }

            Console.ReadLine();
        }
    }
}
