using Task2_Envelopes.Factories;
using Task2_Envelopes.Services;
using Task2_Envelopes.Services.Interfaces;
using Task2_Envelopes.UI;

namespace Task2_Envelopes
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnvelopeFactory envelopeFactory = new EnvelopeFactory();
            IParser parser = new Parser(envelopeFactory);
            IComparator comparator = new Comparator();
            IManager consoleManager = new ConsoleManager();

            new Application(comparator, parser, consoleManager).Start(args);
        }
    }
}
