using Task2_Envelopes.Enums;
using Task2_Envelopes.Models.Interfaces;

namespace Task2_Envelopes.Utils.Interfaces
{
    public interface IComparator
    {
        ResultCompare СheckAttachment(IEnvelope[] envelopes);
    }
}
