using Task6_Tickets.Models.Interfaces;

namespace Task6_Tickets.Models
{
    public class Ticket : ITicket
    {
        #region properties

        public byte[] Number { get; private set; }

        #endregion

        public Ticket(byte[] number)
        {
            Number = number;
        }
    }
}
