using Task4_Parser.Enums;
using Task4_Parser.Services.Interfaces;

namespace Task4_Parser.Services
{
    public class ParserManager : IParserManager
    {
        public IParser GetParser(ValidArgumentsLength validArgumentsLength)
        {
            switch (validArgumentsLength)
            {
                case ValidArgumentsLength.Empty:
                default:
                    return null;
                case ValidArgumentsLength.FileSearch:
                    return new ReaderParser();
                case ValidArgumentsLength.FileSearchReplace:
                    return new SwitcherParser();
            }
        }
    }
}
