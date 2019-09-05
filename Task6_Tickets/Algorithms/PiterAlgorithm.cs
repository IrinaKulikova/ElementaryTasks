using Task6_Tickets.Models.Interfaces;

namespace Task6_Tickets.Algorithms
{
    public class PiterAlgorithm : IAlgorithm
    {
        public bool IsLuckyTicket(ITicket ticket)
        {
            int sumPozitive = 0;
            int sumNegative = 0;

            for (int i = 0; i < ticket.Number.Length; i++)
            {
                if (i % 2 == 0)
                {
                    sumPozitive += ticket.Number[i];
                }
                else
                {
                    sumNegative += ticket.Number[i];
                }
            }

            return sumNegative == sumPozitive;
        }
    }
}
