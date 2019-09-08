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
        #region private fields

        private readonly IDictionary<CellColor, char> _symbols = new Dictionary<CellColor, char>();

        #endregion

        #region ctor

        public BoardView(ConsoleColor color) : base(color)
        {
            _symbols.Add(CellColor.White, ' ');
            _symbols.Add(CellColor.Black, '*');
        }

        #endregion

        public override void Display(IModel model)
        {
            Console.ForegroundColor = Color;

            if ( model is IBoard board )
            {

                for ( int i = 0; i < board.Heigth; i++ )
                {

                    for ( int j = 0; j < board.Width; j++ )
                    {

                        if ( _symbols.TryGetValue(board[i, j].Color, out char symbol) )
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
