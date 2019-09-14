using System;
using static System.Console;

namespace Task4_Parser.UI
{
    public class ConsoleManager : IManager
    {
        public void ShowInstructon()
        {
            WriteLine("You should enter:");
            WriteLine(@" - two arguments (file path , search text)
                            to count entries;");
            WriteLine(@" - three arguments (file path , search text,
                           new text) to replace text.");
            ReadKey();
        }

        public void ShowCount(int count)
        {
            WriteLine("Count entries: " + count);
            ReadKey();
        }

        public void ShowReplacedText(string textResult)
        {
            WriteLine("File has been changed.");
            WriteLine(textResult);
            ReadKey();
        }

        public void InvalidInputArguments(string[] arguments)
        {
            WriteLine("There are invalid arguments: " +
                       String.Join(", ", arguments));
            ReadKey();
        }
    }
}
