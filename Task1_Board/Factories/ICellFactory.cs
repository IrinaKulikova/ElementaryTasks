using Task1_Board.Models;

namespace Task1.Factories
{
    public interface ICellFactory
    {
         Cell Create(int x, int y);
    }
}
