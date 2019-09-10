using Task6_Tickets.Models;
using Task6_Tickets.Models.Interfaces;

namespace Task6_Tickets.Factories
{
    public class TicketFactory : ITicketFactory
    {
        public ITicket Create(int number, int positions)
        {
            if (positions % 2 != 0)
            {
                positions++;
            }

            byte[] numberTicket = new byte[positions];

            for (int i = numberTicket.Length - 1; i >= 0; i--)
            {
                numberTicket[i] = (byte)(number % 10);
                number = number / 10;

                if (number == 0)
                {
                    break;
                }
            }

            return new Ticket(numberTicket);
        }
    }
}
