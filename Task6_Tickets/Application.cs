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

        private readonly IFileReader _fileReader;
        private readonly ILogger _logger;
        private readonly ILuckyTicketCounter _luckyTicketCounter;
        private readonly IManagerAlgorithm _managerAlgorithm;

        #endregion

        public Application(IFileReader fileReader,
                           ILogger logger,
                           ILuckyTicketCounter luckyTicketCounter,
                           IManagerAlgorithm managerAlgorithm)
        {
            _fileReader = fileReader;
            _logger = logger;
            _luckyTicketCounter = luckyTicketCounter;
            _managerAlgorithm = managerAlgorithm;
        }

        public void Start(string[] args)
        {
            //TODO: validator

            if (args == null || args.Length != 1)
            {
                _logger.Error("Invalid arguments: " + String.Join(", ", args));
                return;
            }

            string nameAlgorithm = args[0];

            var algorithmType = _fileReader.GetNameAlgorithm(args[0]);
            var algorithm = _managerAlgorithm.Create(algorithmType);

            _luckyTicketCounter.SetAlgorithm(algorithm);

            int luckyTickets = 0;

            try
            {
                luckyTickets = _luckyTicketCounter.Сalculate(6, 0, 999999);
            }
            catch (NullReferenceException ex)
            {
                _logger.Error(ex);
            }

            Console.WriteLine(luckyTickets);
            Console.ReadKey();
        }
    }
}