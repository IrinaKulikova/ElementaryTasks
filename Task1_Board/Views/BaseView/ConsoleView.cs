using System;
using Task1_Board.Models;

namespace Task1_Board.Views.BaseView
{
    public abstract class ConsoleView
    {
        public ConsoleColor Color { get; private set; } = ConsoleColor.Green;
        public IModel Model { get; private set; }

        public ConsoleView(ConsoleColor color, IModel model)
        {
            Color = color;
            Model = model;
        }

        public abstract void Display();
    }
}