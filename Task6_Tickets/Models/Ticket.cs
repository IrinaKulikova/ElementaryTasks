using Task6_Tickets.Models.Interfaces;

namespace Task6_Tickets.Models
{
    public class Ticket : ITicket
    {
        #region private fields

        private byte[] _number;

        public int Length
        {
            get
            {
                return _number.Length;
            }
        }

        #endregion

        #region properties

        public byte this[int index]
        {
            get
            {
                return _number[index];
            }
        }

        #endregion


        public Ticket(byte[] number)
        {
            _number = number;
        }
    }
}
