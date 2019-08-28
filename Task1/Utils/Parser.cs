using System;
using System.Collections.Generic;
using Task1_Board.Utils.Interfaces;

namespace Task1_Board.Utils
{
    public class Parser : IParser
    {
        public int[] GetValidArgs(string[] args)
        {
            var validArgs = new List<int>();
            foreach (var arg in args)
            {
                try
                {
                    int size = int.Parse(arg);
                    if (size > 0)
                    {
                        validArgs.Add(size);
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
                catch (FormatException ex)
                {
                    throw ex;
                }
                catch (ArgumentException ex)
                {
                    throw ex;
                }
            }
            return validArgs.ToArray();
        }
    }
}
