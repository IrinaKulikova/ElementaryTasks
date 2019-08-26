using System.Collections.Generic;
using System.Text;
using Task1.Enums;

namespace Task1.Models
{
    public class Board : IModel
    {
        public List<List<Cell>> Cells { get; private set; }

        public Board() { }

        public Board(int heigth, int width)
        {
            Cells = new List<List<Cell>>(heigth);
            for (int i = 0; i < heigth; i++)
            {
                var row = new List<Cell>(width);
                for (int j = 0; j < width; j++)
                {
                    row.Add(new Cell { Type = (j + i) % 2 == 1 ? CellColorEnum.Black : CellColorEnum.White });
                }
                Cells.Add(row);
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var row in Cells)
            {
                row.ForEach(cell => builder.Append(cell));
                builder.Append("\n");
            }
            return builder.ToString();
        }
    }
}
