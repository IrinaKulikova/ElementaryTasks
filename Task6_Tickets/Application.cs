using Logger;
using System;
using Task6_Tickets.Algorithms;
using Task6_Tickets.Enums;
using Task6_Tickets.Services.Interfaces;
using ApplicationInitializer;

namespace Task6_Tickets
{
    public class Application : IApplication
    {
        #region private fields

        private readonly IFileReader fileReader = null;
        private readonly ILogger logger = null;
        private readonly ILuckyTicketCounter luckyTicketCounter = null;
        private readonly IManagerAlgorithm managerAlgorithm = null;

        #endregion

        public Application(IFileReader fileReader,
                           ILogger logger,
                           ILuckyTicketCounter luckyTicketCounter,
                           IManagerAlgorithm managerAlgorithm)
        {
            this.fileReader = fileReader;
            this.logger = logger;
            this.luckyTicketCounter = luckyTicketCounter;
            this.managerAlgorithm = managerAlgorithm;
        }

        public void Start(string[] args)
        {
            //TODO: validator

            Algorithm algorithmType = fileReader.GetNameAlgorithm(args[0]);
            IAlgorithm algorithm = managerAlgorithm.Create(algorithmType);

            luckyTicketCounter.SetAlgorithm(algorithm);

            int luckyTickets = luckyTicketCounter.Сalculate(6, 0, 999999);

            Console.WriteLine(luckyTickets);
            Console.ReadKey();
        }
    }
}