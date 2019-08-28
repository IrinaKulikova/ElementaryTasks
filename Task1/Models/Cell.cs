using Task1_Board.Enums;

namespace Task1_Board.Models
{
    public class Cell
    {
        public CellColor Color { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public Cell(int y, int x)
        {
            Y = y;
            X = x;
            Color = ( Y + X ) % 2 == 0 ? CellColor.Black : CellColor.White;
        }
    }
}
