using Task2_Envelopes.Enums;
using Task2_Envelopes.UI;
using Task2_Envelopes.Services.Interfaces;
using Task2_Envelopes.DTOModels;
using Task2_Envelopes.Models.Interfaces;
using DIResolver;
using Logger;
using Task2_Envelopes.Factories;
using CustomCollections;

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
        readonly IValidator validatorArguments;
        readonly IFactoryEnvelopeDTO factoryEnvelopeDTO = null;

        public event DisplayResult DisplayResult;
        public event EnvelopsReader EnvelopsReader;
        public event AnswerReader Continue;
        public event Instruction ShowInstruction;

        public Application(IComparator comparator, IManager consoleManager,
                           ILogger logger, IEnvelopeMapper envelopeMapper,
                           IValidator validatorArguments,
                           IFactoryEnvelopeDTO factoryEnvelopeDTO)
        {
            this.comparator = comparator;
            this.consoleManager = consoleManager;
            this.logger = logger;
            this.envelopeMapper = envelopeMapper;
            this.validatorArguments = validatorArguments;
            this.factoryEnvelopeDTO = factoryEnvelopeDTO;
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

                if (validatorArguments.IsValid(args))
                {
                    envelopeDTO1 = factoryEnvelopeDTO.Create(args[0], args[1]);
                    envelopeDTO2 = factoryEnvelopeDTO.Create(args[2], args[3]);
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

                args = null;

            } while (Continue?.Invoke() == Answer.Yes);

            unsubscribe();
        }
    }
}