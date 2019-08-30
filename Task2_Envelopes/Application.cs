using Task2_Envelopes.Enums;
using Task2_Envelopes.UI;
using Task2_Envelopes.Services.Interfaces;
using Task2_Envelopes.DTOModels;
using Task2_Envelopes.Models.Interfaces;
using DIResolver;
using Logger;

namespace Task2_Envelopes
{
    public delegate void DisplayResult(ResultEnvelopeCompare result);
    public delegate void Instruction();
    public delegate EnvelopeDTO EnvelopsReader();
    public delegate Answer AnswerReader();

    public class Application : IApplication
    {
        readonly IComparator comparator = null;
        readonly IManager consoleManager = null;
        readonly ILogger logger = null;
        readonly IEnvelopeMapper envelopeMapper = null;

        public event DisplayResult DisplayResult;
        public event EnvelopsReader EnvelopsReader;
        public event AnswerReader Continue;
        public event Instruction ShowInstruction;

        public Application(IComparator comparator, IManager consoleManager,
                           ILogger logger, IEnvelopeMapper envelopeMapper)
        {
            this.comparator = comparator;
            this.consoleManager = consoleManager;
            this.logger = logger;
            this.envelopeMapper = envelopeMapper;
        }

        #region PRIVATE METHODS

        private void subscribe()
        {
            DisplayResult += consoleManager.WriteResult;
            EnvelopsReader += consoleManager.GetParametersEnvelopes;
            Continue += consoleManager.ReadAnswerContinue;
            ShowInstruction += consoleManager.ShowInstruction;
            envelopeMapper.ShowError += consoleManager.ShowError;
        }

        private void unsubscribe()
        {
            DisplayResult -= consoleManager.WriteResult;
            EnvelopsReader -= consoleManager.GetParametersEnvelopes;
            Continue -= consoleManager.ReadAnswerContinue;
            ShowInstruction -= consoleManager.ShowInstruction;
            envelopeMapper.ShowError -= consoleManager.ShowError;
        }

        private static bool validArguments(string[] args)
        {
            return args != null && args.Length == (int)CountArgument.Necessary;
        }

        #endregion

        public void Start(string[] args)
        {
            subscribe();

            if (!validArguments(args))
            {
                ShowInstruction?.Invoke();
            }

            do
            {
                EnvelopeDTO envelopeDTO1 = null;
                EnvelopeDTO envelopeDTO2 = null;

                if (validArguments(args))
                {
                    envelopeDTO1 = new EnvelopeDTO(args[0], args[1]);
                    envelopeDTO2 = new EnvelopeDTO(args[2], args[3]);
                }
                else
                {
                    envelopeDTO1 = EnvelopsReader?.Invoke();
                    envelopeDTO2 = EnvelopsReader?.Invoke();
                }

                IEnvelope envelope1 = envelopeMapper.Map(envelopeDTO1);
                IEnvelope envelope2 = envelopeMapper.Map(envelopeDTO2);                

                if (envelope1 != null && envelope2 != null)
                {
                    DisplayResult?.Invoke(comparator.СheckAttachment(envelope1, envelope2));
                }

            } while (Continue?.Invoke() == Answer.Yes);

            unsubscribe();
        }
    }
}