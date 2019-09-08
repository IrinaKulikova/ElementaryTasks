using Task1_Board.Models.Interfaces;

namespace Task1_Board.Models
{
    public class Board : IBoard
    {
        #region private fields

        private readonly ICell[,] cells = null;

        #endregion

        #region properties

        public int Heigth { get; private set; }

        public int Width { get; private set; }

        #endregion

        public ICell this[int i, int j]
        {
            get => cells[i, j];
            set => cells[i, j] = value;
        }

        public Board(int heigth, int width, ICell[,] cells)
        {
            Heigth = heigth;
            Width = width;
            this.cells = cells;
        }
    }
}
