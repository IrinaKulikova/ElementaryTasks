using Task1_Board.Models.Interfaces;

namespace Task1.Factories
{
    public interface IBoardFactory
    {
        IBoard Create(int heigth, int width);
    }
}
