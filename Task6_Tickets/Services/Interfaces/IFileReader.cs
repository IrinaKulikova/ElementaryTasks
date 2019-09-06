using Task6_Tickets.Enums;

namespace Task6_Tickets.Services.Interfaces
{
    public interface IFileReader
    {
        Algorithm GetNameAlgorithm(string path);
    }
}
