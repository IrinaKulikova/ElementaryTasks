using Task1_Board.Enums;
using Task1_Board.Models;

namespace Task1_Board.Factories
{
    public class CellFactory : ICellFactory
    {
        public Cell Create(int x, int y)
        {
            var color = (y + x) % 2 == 0 ? CellColor.Black : CellColor.White;
            return new Cell(y, x, color);
        }
    }
}
