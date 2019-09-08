using Task5_NumberWord.Services;

namespace Task5_NumberWord
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