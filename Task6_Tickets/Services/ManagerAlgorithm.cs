using Logger;
using Task6_Tickets.Algorithms;
using Task6_Tickets.Enums;
using Task6_Tickets.Services.Interfaces;

namespace Task6_Tickets.Services
{
    public class ManagerAlgorithm : IManagerAlgorithm
    {

        #region private fields

        private readonly ILogger logger = null;

        #endregion

        public ManagerAlgorithm(ILogger logger)
        {
            this.logger = logger;
        }

        public IAlgorithm Create(Algorithm algorithmType)
        {
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

            return algorithm;
        }
    }
}
