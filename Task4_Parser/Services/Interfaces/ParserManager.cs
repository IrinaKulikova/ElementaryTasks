using Task4_Parser.Enums;

namespace Task4_Parser.Services.Interfaces
{
    public interface IParserManager
    {
        IParser GetParser(ValidArgumentsLength validArgumentsLength);
    }
}
