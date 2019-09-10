using Task4_Parser.Models;

namespace Task4_Parser.Services.Interfaces
{
    public interface IParserManager
    {
        event Counter CountResult;
        event Replacer ReplaceResult;
        event EmptyOrErrorArguments InvalidArguments;

        void Parse(IInputArguments argumentsLength);
    }
}
