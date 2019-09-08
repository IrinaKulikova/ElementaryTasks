using Task6_Tickets.Models.Interfaces;

namespace Task6_Tickets.Algorithms
{
    public class PiterAlgorithm : IAlgorithm
    {
        public bool IsLuckyTicket(ITicket ticket)
        {
            int sumPozitive = 0;
            int sumNegative = 0;

            for (int i = 0; i < ticket.Length; i++)
            {
                if (i % 2 == 0)
                {
                    sumPozitive += ticket[i];
                }
                else
                {
                    sumNegative += ticket[i];
                }
            }

            return sumNegative == sumPozitive;
        }
    }
}
