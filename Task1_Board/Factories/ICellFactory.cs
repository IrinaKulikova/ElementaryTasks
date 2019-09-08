using Task1_Board.Models;

namespace Task1_Board.Factories
{
    public interface ICellFactory
    {
         ICell Create(int x, int y);
    }
}
