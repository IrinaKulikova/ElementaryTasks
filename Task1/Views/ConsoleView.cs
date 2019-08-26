using System;
using Task1.Models;

namespace Task1.Views
{
    public abstract class ConsoleView
    {
        public ConsoleColor Color { get; set; } = ConsoleColor.Green;

        public ConsoleView() { }

        public ConsoleView(ConsoleColor color)
        {
            Color = color;
        }

        public virtual void Display(IModel model)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine(model?.ToString());
            Console.ReadLine();
        }
    }
}