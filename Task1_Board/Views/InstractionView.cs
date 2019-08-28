using System;
using Task1_Board.Models;
using Task1_Board.Models.Interfaces;
using Task1_Board.Views.BaseView;


namespace Task1_Board.Views
{
    public class InstractionView : ConsoleView
    {
        public InstractionView(ConsoleColor color) : base(color) { }

        public override void Display(IModel model)
        {
            Console.ForegroundColor = Color;

            if ( model is IMessage instraction )
            {
                Console.WriteLine(instraction.Message);
            }

            Console.ReadLine();
        }
    }
}