using Task1_Board.Models.Interfaces;

namespace Task1_Board.Factories
{
    public interface IBoardFactory
    {
        IBoard Create(int heigth, int width);
    }
}
