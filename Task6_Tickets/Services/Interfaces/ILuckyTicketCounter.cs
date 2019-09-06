using Task6_Tickets.Algorithms;

namespace Task6_Tickets.Services.Interfaces
{
    public interface ILuckyTicketCounter
    {
        void SetAlgorithm(IAlgorithm algorithm);
        int Сalculate(int position = 6, int min = 0, int max = 999999);
    }
}
