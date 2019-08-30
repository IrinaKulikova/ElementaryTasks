using Task2_Envelopes.Enums;
using Task2_Envelopes.Models.Interfaces;
using Task2_Envelopes.Services.Interfaces;

namespace Task2_Envelopes.Services
{
    public class Comparator : IComparator
    {
        public ResultEnvelopeCompare СheckAttachment(IEnvelope first, IEnvelope second)
        {
            if (first.Height == second.Height && first.Width == second.Width)
            {
                return ResultEnvelopeCompare.Equales;
            }

            if (first.Height >= second.Height && first.Width >= second.Width)
            {
                return ResultEnvelopeCompare.FistBigger;
            }

            if (second.Height >= first.Height && second.Width >= first.Width)
            {
                return ResultEnvelopeCompare.SecondBigger;
            }

            return ResultEnvelopeCompare.NoFit;
        }
    }
}