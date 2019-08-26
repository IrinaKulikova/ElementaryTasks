using Task1.Enums;

namespace Task1.Models
{
    public class Cell
    {
        public CellColorEnum Type { get; set; }
        public override string ToString() => Type == CellColorEnum.Black ? " " : "*";
    }
}
