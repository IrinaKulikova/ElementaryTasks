using Task1_Board.Enums;

namespace Task1_Board.Models
{
    public class Cell : ICell
    {
        #region private fields

        private readonly CellColor _color;
        private readonly int _x;
        private readonly int _y;

        #endregion

        #region properties

        public CellColor Color { get => _color; }

        #endregion

        public Cell(int y, int x, CellColor color)
        {
            _y = y;
            _x = x;
            _color = color;
        }
    }
}
