using System.Collections.Generic;
using Task6_Tickets.Factories;
using Task6_Tickets.Models.Interfaces;
using Task6_Tickets.Services.Interfaces;

namespace Task6_Tickets.Services
{
    public class TicketGenerator : ITicketGenerator
    {
        #region private fields

        private readonly ITicketFactory _ticketFactory;

        #endregion

        public TicketGenerator(ITicketFactory ticketFactory)
        {
            _ticketFactory = ticketFactory;
        }

        public List<ITicket> GetTickets(int positions = 6, int min = 1, int max = 999999)
        {
            var listTikets = new List<ITicket>(max - min);

            for (int i = min; i <= max; i++)
            {
                ITicket ticket = _ticketFactory.Create(i, positions);
                listTikets.Add(ticket);
            }

            return listTikets;
        }
    }
}
