﻿using System;
using System.Collections.Generic;


namespace Task8_Fibonacci.UI
{
    public class ConsoleManager : IManager
    {
        public void ShowInstruction()
        {
            Console.WriteLine("You should enter the range limits (min, max)");
            Console.ReadKey();
        }

        public void ShowResult(IEnumerable<int> sequence)
        {
            foreach (var number in sequence)
            {
                Console.Write(number + ", ");
            }

            Console.ReadKey();
        }
    }
}
