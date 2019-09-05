using System.Collections.Generic;
using Task6_Tickets.Models.Interfaces;

namespace Task6_Tickets.Services.Interfaces
{
    public interface ITicketGenerator
    {
        List<ITicket> GetTickets(int positions = 6, int min = 1, int max = 999999);
    }
}
