using Task1.Services;
using Task1.Services.Interfaces;

namespace Task1_Board
{
    class Program
    {

        static void Main(string[] args)
        {
            IDIResolver resolver = new DIResolver();
            resolver.Build().Start(args);
        }
    }
}
