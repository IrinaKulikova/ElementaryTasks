using Task6_Tickets.Models.Interfaces;

namespace Task6_Tickets.Factories
{
    public interface ITicketFactory
    {
        ITicket Create(int number, int positions);
    }
}
