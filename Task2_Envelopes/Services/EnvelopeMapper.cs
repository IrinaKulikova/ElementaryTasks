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
        #region private fields

        private readonly IParser _parser;
        private readonly ILogger _logger;

        #endregion

        public event Error ShowError;

        public EnvelopeMapper(IParser parser, ILogger logger)
        {
            _logger = logger;
            _parser = parser;
        }

        public IEnvelope Map(EnvelopeDTO envelopeDTO)
        {
            IEnvelope envelope = null;

            try
            {
                envelope = _parser.GetEnvelope(envelopeDTO);
            }
            catch (ArgumentException ex)
            {
                _logger.Error(ex);
                ShowError?.Invoke(envelopeDTO);
            }
            catch (FormatException ex)
            {
                _logger.Error(ex);
                ShowError?.Invoke(envelopeDTO);
            }
            catch (OverflowException ex)
            {
                _logger.Error(ex);
                ShowError?.Invoke(envelopeDTO);
            }

            return envelope;
        }
    }
}
