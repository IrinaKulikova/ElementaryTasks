using Task6_Tickets.Models.Interfaces;

namespace Task6_Tickets.Algorithms
{
    public class MoskowAlgorithm : IAlgorithm
    {
        public bool IsLuckyTicket(ITicket ticket)
        {
            int middle = ticket.Number.Length / 2;

            int leftSum = GetSum(ticket.Number, 0, middle);
            int rightSum = GetSum(ticket.Number, middle, middle);

            return leftSum == rightSum;
        }

        private static int GetSum(byte[] number, int start, int middle)
        {
            int sum = 0;

            for (int i = start; i < start + middle; i++)
            {
                sum += number[i];
            }

            return sum;
        }
    }
}