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

        public Board() { }

        public Board(int heigth, int width)
        {
            Heigth = heigth;
            Width = width;

            Cells = new Cell[Heigth, Width];

            for ( int i = 0; i < Heigth; i++ )
            {

                for ( int j = 0; j < Width; j++ )
                {
                    Cells[i, j] = new Cell(i, j);
                }

            }
        }
    }
}
