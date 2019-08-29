using Task1_Board.Enums;

namespace Task1_Board.Models
{
    public class Cell
    {
        public CellColor Color { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public Cell(int y, int x, CellColor color)
        {
            Y = y;
            X = x;
            Color = color;
        }
    }
}
