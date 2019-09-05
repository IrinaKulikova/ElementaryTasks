using Task6_Tickets.Algorithms;
using Task6_Tickets.Factories;
using Task6_Tickets.Models.Interfaces;
using Task6_Tickets.Services.Interfaces;

namespace Task6_Tickets.Services
{
    public class LuckyTicketCounter : ILuckyTicketCounter
    {
        private IAlgorithm algorithm = null;
        private readonly ITicketFactory ticketFactory = null;

        public LuckyTicketCounter(ITicketFactory ticketFactory)
        {
            this.ticketFactory = ticketFactory;
        }

        public void SetAlgorithm(IAlgorithm algorithm)
        {
            this.algorithm = algorithm;
        }

        public int Сalculate(int position = 6, int min = 0, int max = 999999)
        {
            int countLuckyTickets = 0;

            for (int i = min; i < max; i++)
            {
                ITicket ticket = ticketFactory.Create(i, position);

                if (algorithm.IsLuckyTicket(ticket))
                {
                    countLuckyTickets++;
                }
            }

            return countLuckyTickets;
        }
    }
}
