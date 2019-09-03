using System;

namespace Task5_NumberWord.UI
{
    public class ManagerConsole : IManagerViews
    {
        public void Instruction()
        {
            Console.WriteLine("Instruction: ...");
            Console.ReadKey();
        }

        public void ShowResultWords(string numberWords)
        {
            Console.Write(numberWords);
            Console.ReadKey();
        }
    }
}