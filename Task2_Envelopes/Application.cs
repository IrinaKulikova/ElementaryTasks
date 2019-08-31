using Task2_Envelopes.Enums;
using Task2_Envelopes.UI;
using Task2_Envelopes.Services.Interfaces;
using Task2_Envelopes.DTOModels;
using DIResolver;
using Logger;
using Task2_Envelopes.Containers.interfaces;

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
        readonly IValidator validatorArguments;
        readonly IEnvelopeContainer envelopesContainer = null;
        readonly IEnvelopeMapper envelopeMapper = null;

        public event DisplayResult DisplayResult;
        public event EnvelopsReader EnvelopsReader;
        public event AnswerReader Continue;
        public event Instruction ShowInstruction;

        public Application(IComparator comparator,
                           IManager consoleManager,
                           ILogger logger,
                           IValidator validatorArguments,
                           IEnvelopeContainer envelopesContainer,
                           IEnvelopeMapper envelopeMapper)
        {
            this.comparator = comparator;
            this.consoleManager = consoleManager;
            this.logger = logger;
            this.validatorArguments = validatorArguments;
            this.envelopesContainer = envelopesContainer;
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

        #endregion


        public void Start(string[] args)
        {
            subscribe();

            if (!validatorArguments.IsValid(args))
            {
                ShowInstruction?.Invoke();
            }

            do
            {
                EnvelopeDTO envelopeDTO1 = null;
                EnvelopeDTO envelopeDTO2 = null;

                if (!validatorArguments.IsValid(args))
                {
                    envelopeDTO1 = EnvelopsReader?.Invoke();
                    envelopeDTO2 = EnvelopsReader?.Invoke();
                }

                envelopesContainer.UpdateEnvelopes(args, envelopeDTO1, envelopeDTO2);

                if (envelopesContainer.FirstEnvelope != null &&
                    envelopesContainer.SecondEnvelope != null)
                {
                    var campareResult = comparator.СheckAttachment(envelopesContainer.FirstEnvelope,
                                                                   envelopesContainer.SecondEnvelope);
                    DisplayResult?.Invoke(campareResult);
                }

            } while (Continue?.Invoke() == Answer.Yes);

            unsubscribe();
        }
    }
}