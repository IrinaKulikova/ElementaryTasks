using Task6_Tickets.Algorithms;
using Task6_Tickets.Enums;

namespace Task6_Tickets.Services.Interfaces
{
    public interface IManagerAlgorithm
    {
        IAlgorithm Create(Algorithm algorithmType);
    }
}
