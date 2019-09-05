using DIResolver;
using Logger;
using System;
using Task6_Tickets.Algorithms;
using Task6_Tickets.Enums;
using Task6_Tickets.Services.Interfaces;

namespace Task6_Tickets
{
    public class Application : IApplication
    {
        #region PRIVATE FIELDS

        readonly IFileReader fileReader = null;
        readonly ILogger logger = null;
        readonly ILuckyTicketCounter luckyTicketCounter = null;
        readonly IManagerAlgorithm managerAlgorithm = null;

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
            Algorithm algorithmType = fileReader.GetNameAlgorithm(args[0]);
            IAlgorithm algorithm = managerAlgorithm.Create(algorithmType);

            luckyTicketCounter.SetAlgorithm(algorithm);

            int luckyTickets = luckyTicketCounter.Сalculate(8, 0, 99999999);

            Console.WriteLine(luckyTickets);
            Console.ReadKey();
        }
    }
}