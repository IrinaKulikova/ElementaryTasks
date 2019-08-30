using Task2_Envelopes.Enums;
using Task2_Envelopes.UI;
using Task2_Envelopes.Services.Interfaces;
using Task2_Envelopes.DTOModels;

namespace Task2_Envelopes
{
    public delegate void DisplayResult(ResultEnvelopeCompare result);
    public delegate void Instruction();
    public delegate EnvelopeDTO EnvelopsReader();
    public delegate Answer AnswerReader();


    public class Application
    {
        readonly IComparator comparator = null;
        readonly IParser parser = null;
        readonly IManager consoleManager = null;

        public event DisplayResult DisplayResult;
        public event EnvelopsReader EnvelopsReader;
        public event AnswerReader Continue;
        public event Instruction ShowInstruction;

        public Application(IComparator comparator, IParser parser, IManager consoleManager)
        {
            this.comparator = comparator;
            this.parser = parser;
            this.consoleManager = consoleManager;

            Subscribe();
        }

        private void Subscribe()
        {
            DisplayResult += consoleManager.WriteResult;
            EnvelopsReader += consoleManager.GetParametersEnvelopes;
            Continue += consoleManager.ReadAnswerContinue;
            ShowInstruction += consoleManager.ShowInstruction;
        }

        public void Start(string[] args)
        {
            if (args == null || args.Length != 4)
            {
                ShowInstruction?.Invoke();
            }

            do
            {
                EnvelopeDTO envelope1 = null;
                EnvelopeDTO envelope2 = null;

                if (args != null || args.Length == 4)
                {
                    envelope1 = new EnvelopeDTO(args[0], args[1]);
                    envelope2 = new EnvelopeDTO(args[2], args[3]);
                }
                else
                {
                    envelope1 = EnvelopsReader?.Invoke();
                    envelope2 = EnvelopsReader?.Invoke();
                }

                var envelopes = parser.GetEnvelopes(args);
                var result = comparator.СheckAttachment(envelopes[0], envelopes[1]);
                DisplayResult?.Invoke(result);

                args = null;

            } while (Continue?.Invoke() == Answer.Yes);
        }
    }
}
