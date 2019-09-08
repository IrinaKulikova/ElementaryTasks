using Task3_Triangles.Services;

namespace Task3_Triangles
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