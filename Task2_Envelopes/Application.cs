using Task2_Envelopes.Enums;
using Task2_Envelopes.UI;
using Task2_Envelopes.Services.Interfaces;
using Task2_Envelopes.DTOModels;
using Logger;
using Task2_Envelopes.Containers.interfaces;
using ApplicationInitializer;

namespace Task2_Envelopes
{
    public delegate void DisplayResult(ResultEnvelopeCompare result);
    public delegate void Instruction();
    public delegate EnvelopeDTO EnvelopsReader();
    public delegate Answer AnswerReader();

    public class Application : IApplication
    {
        #region private fields

        private readonly IComparator comparator = null;
        private readonly IManager consoleManager = null;
        private readonly ILogger logger = null;
        private readonly IValidator validatorArguments;
        private readonly IEnvelopeContainer envelopesContainer = null;
        private readonly IEnvelopeMapper envelopeMapper = null;

        #endregion

        #region events

        public event DisplayResult DisplayResult;
        public event EnvelopsReader EnvelopsReader;
        public event AnswerReader Continue;
        public event Instruction ShowInstruction;

        #endregion

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

        #region private methods

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

            do
            {
                EnvelopeDTO envelopeDTO1 = null;
                EnvelopeDTO envelopeDTO2 = null;

                if (!validatorArguments.IsValid(args))
                {
                    ShowInstruction?.Invoke();

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

                args = null;

            } while (Continue?.Invoke() == Answer.Yes);

            unsubscribe();
        }
    }
}