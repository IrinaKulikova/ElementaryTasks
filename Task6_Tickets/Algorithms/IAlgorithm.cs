using Task6_Tickets.Models.Interfaces;

namespace Task6_Tickets.Algorithms
{
    public interface IAlgorithm
    {
        int GetCountLuckyTickets(ITicket ticket);
    }
}
