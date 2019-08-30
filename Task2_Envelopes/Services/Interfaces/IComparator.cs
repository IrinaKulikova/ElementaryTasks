using Task2_Envelopes.Enums;
using Task2_Envelopes.Models.Interfaces;

namespace Task2_Envelopes.Services.Interfaces
{
    public interface IComparator
    {
        ResultEnvelopeCompare СheckAttachment(IEnvelope first, IEnvelope second);
    }
}
