using DIResolver;
using Task3_Triangles.Services;

namespace Task3_Triangles
{
    class Program
    {
        static void Main(string[] args)
        {
            IResolver resolver = new Resolver();
            IApplication app = resolver.Initialization();
            app.Start(args);
        }
    }
}