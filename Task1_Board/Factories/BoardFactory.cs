using Task1_Board.Models;
using Task1_Board.Models.Interfaces;

namespace Task1_Board.Factories
{
    public class BoardFactory : IBoardFactory
    {
        #region private fields

        private readonly ICellFactory _cellFactory;

        #endregion

        public BoardFactory(ICellFactory cellFactory)
        {
            _cellFactory = cellFactory;
        }

        public IBoard Create(int heigth, int width)
        {
            var cells = new ICell[heigth, width];

            for (int i = 0; i < heigth; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    cells[i, j] = _cellFactory.Create(j, i);
                }
            }

            return new Board(heigth, width, cells);
        }
    }
}
