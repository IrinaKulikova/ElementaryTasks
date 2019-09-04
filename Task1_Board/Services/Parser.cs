using CustomCollections;
using System;
using Task1_Board.Services.Interfaces;

namespace Task1_Board.Services
{
    public class Parser : IParser
    {
        public IArgumentCollection<int> GetValidArgs(string[] args)
        {
            var validArgs = new ArgumentCollection<int>();

            foreach ( var arg in args )
            {
                int size = int.Parse(arg);

                if ( size > 0 )
                {
                    validArgs.Add(size);
                }
                else
                {
                    throw new ArgumentException();
                }

            }
            return validArgs;
        }
    }
}
