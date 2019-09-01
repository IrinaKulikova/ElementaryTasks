using System;
using System.Collections.Generic;

namespace Task5_NumberWord.UI
{
    public class ManagerConsole : IManagerViews
    {
        public void Instruction()
        {
            Console.WriteLine("Instruction");
            Console.ReadKey();
        }

        public void Result(List<string> numberWords)
        {
            numberWords.ForEach(n => Console.Write(n));
            Console.ReadKey();
        }
    }
}