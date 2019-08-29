﻿using Task1_Board.Models;
using Task1_Board.Models.Interfaces;

namespace Task1.Factories
{
    public class BoardFactory : IBoardFactory
    {
        ICellFactory cellFactory = new CellFactory();

        public IBoard Create(int heigth, int width)
        {
            var cells = new Cell[heigth, width];

            for (int i = 0; i < heigth; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    cells[i, j] = cellFactory.Create(j, i);
                }
            }

            return new Board(heigth, width, cells);
        }
    }
}