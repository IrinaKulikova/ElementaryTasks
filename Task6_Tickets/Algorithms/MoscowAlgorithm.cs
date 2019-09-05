using Task6_Tickets.Models.Interfaces;

namespace Task6_Tickets.Algorithms
{
    public class MoskowAlgorithm : IAlgorithm
    {
        public bool GetCountLuckyTickets(ITicket ticket)
        {
            int middle = ticket.Number.Length / 2;
            int sumLeft = getSumPart(ticket.Number, 0, middle - 1);
            int sumRight = getSumPart(ticket.Number, middle - 1, middle);

            return sumLeft == sumRight;
        }

        private int getSumPart(string number, int start, int end)
        {
            int sum = 0;
            string part = number.Substring(start, end);

            foreach (var digit in part)
            {
                sum += int.Parse(digit.ToString());
            }

            return sum;
        }
    }
}