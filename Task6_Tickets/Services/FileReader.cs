using System;
using System.IO;
using Task6_Tickets.Enums;
using Task6_Tickets.Services.Interfaces;

namespace Task6_Tickets.Services
{
    public class FileReader : IFileReader
    {
        public AlgorithmType GetNameAlgorithm(string path)
        {
            var algorithmName = string.Empty;

            if (File.Exists(path))
            {
                using (Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader streamReader = new StreamReader(stream))
                    {
                        algorithmName = streamReader.ReadLine();
                    }
                }
            }

            var algorithm = (AlgorithmType)Enum
                            .Parse(typeof(AlgorithmType),algorithmName);

            return algorithm;
        }
    }
}
