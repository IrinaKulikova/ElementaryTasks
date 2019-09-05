using Task6_Tickets.Models.Interfaces;

namespace Task6_Tickets.Models
{
    public class Ticket : ITicket
    {
        public byte[] Number { get; private set; }

        public Ticket(byte[] number)
        {
            Number = number;
        }
    }
}
