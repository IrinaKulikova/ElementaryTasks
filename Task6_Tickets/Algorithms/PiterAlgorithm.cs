using Task6_Tickets.Models.Interfaces;

namespace Task6_Tickets.Algorithms
{
    public class PiterAlgorithm : IAlgorithm
    {
        public bool GetCountLuckyTickets(ITicket ticket)
        {
            int sumPozitive = 0;
            int sumNegative = 0;

            for (int i = 0; i < ticket.Number.Length; i++)
            {
                int digit = int.Parse(ticket.Number[i].ToString());

                if (i % 2 == 0)
                {
                    sumPozitive += digit;
                }
                else
                {
                    sumNegative += digit;
                }
            }

            return sumNegative == sumPozitive;
        }
    }
}
