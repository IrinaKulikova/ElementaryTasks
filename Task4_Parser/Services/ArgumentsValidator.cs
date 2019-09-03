using System.IO;
using Task4_Parser.Enums;
using Task4_Parser.Services.Interfaces;

namespace Task4_Parser.Services
{
    public class ArgumentsValidator : IArgumentsValidator
    {
        public bool Check(string[] args)
        {
            return isValidLength(args) && File.Exists(args[0]);
        }

        private bool isValidLength(string[] args)
        {
            return checkTwoArguments(args) || checkThreeArguments(args);
        }

        private bool checkTwoArguments(string[] args)
        {
            return args.Length == (int)ValidArgumentsLength.FileSearch;
        }

        private bool checkThreeArguments(string[] args)
        {
            return args.Length == (int)ValidArgumentsLength.FileSearchReplace;
        }

    }
}
