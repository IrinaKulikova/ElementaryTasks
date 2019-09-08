namespace Task6_Tickets.Models.Interfaces
{
    public interface ITicket
    {
        byte this[int index] { get; }
        int Length { get; }
    }
}
