using DIResolver;
using Logger;
using Task6_Tickets.Algorithms;
using Task6_Tickets.Enums;
using Task6_Tickets.Services.Interfaces;

namespace Task6_Tickets
{
    public class Application : IApplication
    {
        IFileReader fileReader = null;
        ILogger logger = null;

        public Application(IFileReader fileReader,
                           ILogger logger)
        {
            this.fileReader = fileReader;
            this.logger = logger;
        }

        public void Start(string[] args)
        {
            Algorithm algorithmType = fileReader.GetNameAlgorithm(args[0]);
            IAlgorithm algorithm = null;

            switch (algorithmType)
            {
                case Algorithm.Moskow:
                    algorithm = new MoskowAlgorithm();
                    break;
                case Algorithm.Piter:
                    algorithm = new PiterAlgorithm();
                    break;
                default:
                    logger.Error("undefined algorithm");
                    break;
            }

        }
    }
}