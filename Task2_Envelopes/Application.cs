using Task2_Envelopes.ConsoleUI;
using Task2_Envelopes.Enums;
using Task2_Envelopes.Utils;
using Task2_Envelopes.Utils.Interfaces;

namespace Task2_Envelopes
{
    public delegate void DisplayResult(ResultCompare result);
    public delegate string[] EnvelopsReader();
    public delegate Answer AnswerReader();


    public class Application
    {
        readonly IComparator comparator = null;
        readonly IParser parser = null;
        readonly UI consoleInterface = null;

        public event DisplayResult DisplayResult;
        public event EnvelopsReader EnvelopsReader;
        public event AnswerReader Continue;

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
            consoleInterface = new ManagerUI();

            Subscribe();
        }

        private void Subscribe()
        {
            DisplayResult += consoleInterface.WriteResult;
            EnvelopsReader += consoleInterface.GetParametersEnvelopes;
            Continue += consoleInterface.ReadAnswerContinue();
        }

        public void Start(string[] args)
        {
            do
            {
                if (args == null || args.Length == 0)
                {
                    args = EnvelopsReader?.Invoke();
                }

                var envelopes = parser.GetEnvelopes(args);
                var result = comparator.СheckAttachment(envelopes);

                DisplayResult?.Invoke(result);

                args = null;

            } while (Continue?.Invoke() == Answer.Yes);
        }
    }
}
