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

        private readonly IEnvelopeMapper envelopeMapper = null;
        private readonly IValidator validatorArguments;
        private readonly IEnvelopeDTOFactory envelopeDTOFactory = null;

        #endregion

        #region properties

        public IEnvelope FirstEnvelope { get; private set; }
        public IEnvelope SecondEnvelope { get; private set; }

        #endregion


        public EnvelopesContainer(IValidator validatorArguments,
                                  IEnvelopeMapper envelopeMapper,
                                  IEnvelopeDTOFactory envelopeDTOFactory)
        {
            this.envelopeDTOFactory = envelopeDTOFactory;
            this.envelopeMapper = envelopeMapper;
            this.validatorArguments = validatorArguments;
        }

        public void UpdateEnvelopes(string[] args, EnvelopeDTO firstEnvelopeDTO, EnvelopeDTO secondEnvelopeDTO)
        {
            if (validatorArguments.IsValid(args))
            {
                firstEnvelopeDTO = envelopeDTOFactory.Create(args[0], args[1]);
                secondEnvelopeDTO = envelopeDTOFactory.Create(args[2], args[3]);
            }

            FirstEnvelope = envelopeMapper.Map(firstEnvelopeDTO);
            SecondEnvelope = envelopeMapper.Map(secondEnvelopeDTO);
        }
    }
}
