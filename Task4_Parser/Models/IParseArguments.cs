namespace Task4_Parser.Models
{
    public interface IParseArguments
    {
        string FilePath { get; }
        string SearchText { get; }
        string NewText { get; }
    }
}
