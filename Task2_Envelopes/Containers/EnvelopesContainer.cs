using Task2_Envelopes.Containers.interfaces;
using Task2_Envelopes.DTOModels;
using Task2_Envelopes.Factories;
using Task2_Envelopes.Models.Interfaces;
using Task2_Envelopes.Services.Interfaces;

namespace Task2_Envelopes.Containers
{
    public class EnvelopesContainer : IEnvelopeContainer
    {
        #region private fields 

        private readonly IEnvelopeMapper _envelopeMapper;
        private readonly IValidator _validatorArguments;
        private readonly IEnvelopeDTOFactory _envelopeDTOFactory;

        #endregion

        #region properties

        public IEnvelope FirstEnvelope { get; private set; }
        public IEnvelope SecondEnvelope { get; private set; }

        #endregion


        public EnvelopesContainer(IValidator validatorArguments,
                                  IEnvelopeMapper envelopeMapper,
                                  IEnvelopeDTOFactory envelopeDTOFactory)
        {
            _envelopeDTOFactory = envelopeDTOFactory;
            _envelopeMapper = envelopeMapper;
            _validatorArguments = validatorArguments;
        }

        public void UpdateEnvelopes(string[] args, EnvelopeDTO firstEnvelopeDTO, EnvelopeDTO secondEnvelopeDTO)
        {
            if (_validatorArguments.IsValid(args))
            {
                firstEnvelopeDTO = _envelopeDTOFactory.Create(args[0], args[1]);
                secondEnvelopeDTO = _envelopeDTOFactory.Create(args[2], args[3]);
            }

            FirstEnvelope = _envelopeMapper.Map(firstEnvelopeDTO);
            SecondEnvelope = _envelopeMapper.Map(secondEnvelopeDTO);
        }
    }
}
