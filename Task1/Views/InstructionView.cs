using System;
using Task1_Board.Models;
using Task1_Board.Models.Interfaces;
using Task1_Board.Views.BaseView;


namespace Task1_Board.Views
{
    public class InstructionView : ConsoleView
    {
        public InstructionView(ConsoleColor color, IModel model) : base(color, model) { }

        public override void Display()
        {
            Console.ForegroundColor = Color;

            if ( Model is IMessage instraction )
            {
                Console.WriteLine(instraction.Message);
            }

            Console.ReadLine();
        }
    }
}