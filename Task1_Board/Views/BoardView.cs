using System;
using System.Collections.Generic;
using Task1_Board.Enums;
using Task1_Board.Models;
using Task1_Board.Models.Interfaces;
using Task1_Board.Views.BaseView;

namespace Task1_Board.Views
{
    class BoardView : ConsoleView
    {
        IDictionary<CellColor, char> Symbols = new Dictionary<CellColor, char>();

        public BoardView(ConsoleColor color, IModel model) : base(color, model)
        {
            Symbols.Add(CellColor.White, ' ');
            Symbols.Add(CellColor.Black, '*');
        }

        public override void Display()
        {
            Console.ForegroundColor = Color;

            if ( Model is IBoard board )
            {

                for ( int i = 0; i < board.Heigth; i++ )
                {

                    for ( int j = 0; j < board.Width; j++ )
                    {

                        if ( Symbols.TryGetValue(board[i, j].Color, out char symbol) )
                        {
                            Console.Write(symbol);
                        }

                    }

                    Console.WriteLine();
                }

            }
            Console.ReadLine();
        }
    }
}
