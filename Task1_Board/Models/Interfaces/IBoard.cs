namespace Task1_Board.Models.Interfaces
{
    public interface IBoard : IModel
    {
        int Heigth { get; }
        int Width { get; }
        Cell this[int i, int j] { get; }
    }
}
