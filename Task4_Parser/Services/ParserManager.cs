using Logger;
using Task4_Parser.Enums;
using Task4_Parser.Models;
using Task4_Parser.Services.Interfaces;

namespace Task4_Parser.Services
{
    public class ParserManager : IParserManager
    {
        #region private fields

        private readonly ILogger _logger;

        #endregion

        #region events

        public event Counter CountResult;
        public event Replacer ReplaceResult;
        public event EmptyOrErrorArguments InvalidArguments;

        #endregion

        #region ctor

        public ParserManager(ILogger logger)
        {
            _logger = logger;
        }

        #endregion

        public void Parse(IInputArguments argumentsLength)
        {
            switch (argumentsLength.ArgumentsLength)
            {
                case ValidArgumentsLength.Empty:
                default:
                    InvalidArguments?.Invoke();
                    break;

                case ValidArgumentsLength.FileSearch:
                    int count = GetCountEntries(argumentsLength);
                    CountResult?.Invoke(count);
                    break;

                case ValidArgumentsLength.FileSearchReplace:
                    GetCountEntriesAndReplace(argumentsLength);
                    ReplaceResult?.Invoke();
                    break;
            }
        }


        public void GetCountEntriesAndReplace(IInputArguments arguments)
        {
            using (var replacer = new FileStreamReplacer(arguments, _logger))
            {
                var parser = new ParserReplacer();

                foreach (var line in replacer.GetLine())
                {
                    string newText = parser.Replace(line, arguments);
                    replacer.SetText(newText);
                }
            }
        }


        public int GetCountEntries(IInputArguments arguments)
        {
            int count = 0;

            using (var counter = new FileStreamCounter(arguments, _logger))
            {
                var parser = new ParserCounter();

                foreach (var line in counter.GetLine())
                {
                    count += parser.Calculate(line, arguments);
                }
            }

            return count;
        }
    }
}