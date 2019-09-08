using System;
using Task2_Envelopes.DTOModels;
using Task2_Envelopes.Factories;
using Task2_Envelopes.Models.Interfaces;
using Task2_Envelopes.Services.Interfaces;

namespace Task2_Envelopes.Services
{
    public class Parser : IParser
    {
        #region private fields

        private readonly IEnvelopeFactory _envelopeFactory;

        #endregion

        public Parser(IEnvelopeFactory envelopeFactory)
        {
            _envelopeFactory = envelopeFactory;
        }

        public IEnvelope GetEnvelope(EnvelopeDTO envelopeDTO)
        {
            var height = float.Parse(envelopeDTO.Heigth);
            var width = float.Parse(envelopeDTO.Width);

            if (height < 0 || width < 0)
            {
                throw new ArgumentException();
            }
            return _envelopeFactory.Create(height, width);
        }
    }
}
