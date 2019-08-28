using Task2_Envelopes.ConsoleUI;
using Task2_Envelopes.Enums;
using Task2_Envelopes.Utils;
using Task2_Envelopes.Utils.Interfaces;

namespace Task2_Envelopes
{
    public delegate void DisplayResult(ResultCompare result);
    public delegate string[] EnvelopsReader();

    public class Application
    {
        readonly IComparator comparator = null;
        readonly IParser parser = null;
        readonly UI consoleInterface = null;

        public event DisplayResult DisplayResult;
        public event EnvelopsReader EnvelopsReader;

        public Application(IComparator comparator, IParser parser, UI consoleInterface)
        {
            this.comparator = comparator;
            this.parser = parser;
            this.consoleInterface = consoleInterface;

            Subscribe();
        }

        public Application()
        {
            comparator = new Comparator();
            parser = new Parser();
            consoleInterface = new ConsoleInterface();

            Subscribe();
        }

        private void Subscribe()
        {
            DisplayResult += consoleInterface.WriteResult;
            EnvelopsReader += consoleInterface.GetParametersEnvelopes;
        }

        public void Start(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                args = EnvelopsReader?.Invoke();
            }

            var first = parser.GetEnvelope(args?[0], args?[1]);
            var second = parser.GetEnvelope(args?[2], args?[3]);

            if (first != null && second != null)
            {
                var result = comparator.СheckAttachment(first, second);
                DisplayResult?.Invoke(result);
            }
        }
    }
}
