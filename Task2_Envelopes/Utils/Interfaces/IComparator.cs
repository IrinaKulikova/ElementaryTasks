using Task2_Envelopes.Enums;
using Task2_Envelopes.Models;

namespace Task2_Envelopes.Utils.Interfaces
{
    public interface IComparator
    {
        ResultCompare СheckAttachment(Envelope first, Envelope second);
    }
}
