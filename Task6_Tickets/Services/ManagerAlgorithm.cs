using Logger;
using Task6_Tickets.Algorithms;
using Task6_Tickets.Enums;
using Task6_Tickets.Services.Interfaces;

namespace Task6_Tickets.Services
{
    public class ManagerAlgorithm : IManagerAlgorithm
    {

        #region private fields

        private readonly ILogger _logger;

        #endregion

        public ManagerAlgorithm(ILogger logger)
        {
            _logger = logger;
        }

        public IAlgorithm Create(AlgorithmType algorithmType)
        {
            IAlgorithm algorithm = null;

            switch (algorithmType)
            {
                case AlgorithmType.Moskow:
                    algorithm = new MoskowAlgorithm();
                    break;
                case AlgorithmType.Piter:
                    algorithm = new PiterAlgorithm();
                    break;
                default:
                    _logger.Error("undefined algorithm");
                    break;
            }

            return algorithm;
        }
    }
}
