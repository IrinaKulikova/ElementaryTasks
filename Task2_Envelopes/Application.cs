using Task2_Envelopes.Enums;
using Task2_Envelopes.UI;
using Task2_Envelopes.Services.Interfaces;
using Task2_Envelopes.DTOModels;
using Task2_Envelopes.Models.Interfaces;
using System;
using DIResolver;
using Logger;

namespace Task2_Envelopes
{
    public delegate void DisplayResult(ResultEnvelopeCompare result);
    public delegate void Instruction();
    public delegate EnvelopeDTO EnvelopsReader();
    public delegate Answer AnswerReader();
    public delegate void Error();

    public class Application : IApplication
    {
        readonly IComparator comparator = null;
        readonly IParser parser = null;
        readonly IManager consoleManager = null;
        readonly ILogger logger = null;

        public event DisplayResult DisplayResult;
        public event EnvelopsReader EnvelopsReader;
        public event AnswerReader Continue;
        public event Instruction ShowInstruction;
        public event Error ShowError;

        public Application(IComparator comparator, IParser parser,
                           IManager consoleManager, ILogger logger)
        {
            this.comparator = comparator;
            this.parser = parser;
            this.consoleManager = consoleManager;
            this.logger = logger;

            Subscribe();
        }

        private void Subscribe()
        {
            DisplayResult += consoleManager.WriteResult;
            EnvelopsReader += consoleManager.GetParametersEnvelopes;
            Continue += consoleManager.ReadAnswerContinue;
            ShowInstruction += consoleManager.ShowInstruction;
            ShowError += consoleManager.ShowError;
        }

        public void Start(string[] args)
        {
            if (args == null || args.Length != 4)
            {
                ShowInstruction?.Invoke();
            }

            do
            {
                EnvelopeDTO envelopeDTO1 = null;
                EnvelopeDTO envelopeDTO2 = null;

                getEnvelopParameters(args, out envelopeDTO1, out envelopeDTO2);

                try
                {
                    IEnvelope envelope1 = parser.GetEnvelope(envelopeDTO1);
                    IEnvelope envelope2 = parser.GetEnvelope(envelopeDTO2);

                    var result = comparator.СheckAttachment(envelope1, envelope2);
                    DisplayResult?.Invoke(result);

                }
                catch (ArgumentException ex)
                {
                    ShowError?.Invoke();
                    logger.Error(ex);
                }
                catch (FormatException ex)
                {
                    ShowError?.Invoke();
                    logger.Error(ex);
                }
                catch (OverflowException ex)
                {
                    ShowError?.Invoke();
                    logger.Error(ex);
                }
                finally
                {
                    args = null;
                }

            } while (Continue?.Invoke() == Answer.Yes);
        }


        private void getEnvelopParameters(string[] args, out EnvelopeDTO envelopeDTO1, out EnvelopeDTO envelopeDTO2)
        {
            if (args != null && args.Length == 4)
            {
                envelopeDTO1 = new EnvelopeDTO(args[0], args[1]);
                envelopeDTO2 = new EnvelopeDTO(args[2], args[3]);
            }
            else
            {
                envelopeDTO1 = EnvelopsReader?.Invoke();
                envelopeDTO2 = EnvelopsReader?.Invoke();
            }
        }
    }
}
