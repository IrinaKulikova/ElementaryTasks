using System;
using Task6_Tickets.Algorithms;
using Task6_Tickets.Factories;
using Task6_Tickets.Models.Interfaces;
using Task6_Tickets.Services.Interfaces;

namespace Task6_Tickets.Services
{
    public class LuckyTicketCounter : ILuckyTicketCounter
    {
        #region private fields

        private IAlgorithm _algorithm;
        private readonly ITicketFactory _ticketFactory;

        #endregion

        public LuckyTicketCounter(ITicketFactory ticketFactory)
        {
            _ticketFactory = ticketFactory;
        }

        public void SetAlgorithm(IAlgorithm algorithm)
        {
            _algorithm = algorithm;
        }

        public int Сalculate(int position = 6, int min = 0, int max = 999999)
        {
            if (_algorithm == null)
            {
                throw new NullReferenceException("algorithm is null");
            }

            int countLuckyTickets = 0;

            for (int i = min; i <= max; i++)
            {
                ITicket ticket = _ticketFactory.Create(i, position);

                if (_algorithm.IsLuckyTicket(ticket))
                {
                    countLuckyTickets++;
                }
            }

            return countLuckyTickets;
        }
    }
}
