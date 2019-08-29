using Task1.Factories;
using Task1_Board.Models.Interfaces;

namespace Task1_Board.Models
{
    public class Board : IBoard
    {
        private Cell[,] Cells { get; set; }

        public int Heigth { get; private set; }

        public int Width { get; private set; }

        public Cell this[int i, int j]
        {
            get => Cells[i, j];
            set => Cells[i, j] = value;
        }

        public Board(int heigth, int width, Cell[,] cells)
        {
            Heigth = heigth;
            Width = width;
            Cells = cells;
        }        
    }
}
