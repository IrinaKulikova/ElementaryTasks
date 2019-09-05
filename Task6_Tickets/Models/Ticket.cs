using Task6_Tickets.Models.Interfaces;

namespace Task6_Tickets.Models
{
    public class Ticket : ITicket
    {
        public string Number { get; private set; }

        public Ticket(string number)
        {
            Number = number;
        }
    }
}
