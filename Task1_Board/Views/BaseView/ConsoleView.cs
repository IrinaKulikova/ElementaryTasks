using System;
using Task1_Board.Models;

namespace Task1_Board.Views.BaseView
{
    public abstract class ConsoleView
    {
        public ConsoleColor Color { get; private set; } = ConsoleColor.Green;

        public ConsoleView(ConsoleColor color)
        {
            Color = color;
        }

        public abstract void Display(IModel model);
    }
}