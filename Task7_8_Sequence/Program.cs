using Task8_Fibonacci.Services;

namespace Task8_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            var initializer = new Initializer();
            var app = initializer.InitializeApplication();
            app.Start(args);
        }
    }
}
