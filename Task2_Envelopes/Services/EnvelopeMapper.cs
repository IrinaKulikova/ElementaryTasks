using Logger;
using System;
using Task2_Envelopes.DTOModels;
using Task2_Envelopes.Models.Interfaces;
using Task2_Envelopes.Services.Interfaces;

namespace Task2_Envelopes.Services
{
    public delegate void Error(EnvelopeDTO envelopeDTO);

    public class EnvelopeMapper : IEnvelopeMapper
    {
        IParser parser = null;
        ILogger logger = null;
        public event Error ShowError;

        public EnvelopeMapper(IParser parser, ILogger logger)
        {
            this.logger = logger;
            this.parser = parser;
        }

        public IEnvelope Map(EnvelopeDTO envelopeDTO)
        {
            IEnvelope envelope = null;
            try
            {
                envelope = parser.GetEnvelope(envelopeDTO);
            }
            catch (ArgumentException ex)
            {
                logger.Error(ex);
                ShowError?.Invoke(envelopeDTO);
            }
            catch (FormatException ex)
            {
                logger.Error(ex);
                ShowError?.Invoke(envelopeDTO);
            }
            catch (OverflowException ex)
            {
                logger.Error(ex);
                ShowError?.Invoke(envelopeDTO);
            }
            return envelope;
        }
    }
}
