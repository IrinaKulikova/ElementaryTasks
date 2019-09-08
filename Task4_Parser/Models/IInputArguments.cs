using Task4_Parser.Enums;

namespace Task4_Parser.Models
{
    public interface IInputArguments
    {
        string FilePath { get; }
        string SearchText { get; }
        string NewText { get; }
        ValidArgumentsLength ArgumentsLength { get; }
    }
}
