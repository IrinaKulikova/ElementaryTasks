using Task7_8_Sequence.Services;

namespace Task7_8_Sequence
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
