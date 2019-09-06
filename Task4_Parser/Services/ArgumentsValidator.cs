using System.IO;
using Task4_Parser.Enums;
using Task4_Parser.Services.Interfaces;

namespace Task4_Parser.Services
{
    public class ArgumentsValidator : IArgumentsValidator
    {
        public bool Check(string[] args)
        {
            return IsValidLength(args) && File.Exists(args[0]);
        }

        private bool IsValidLength(string[] args)
        {
            return CheckTwoArguments(args) || CheckThreeArguments(args);
        }

        private bool CheckTwoArguments(string[] args)
        {
            return args.Length == (int)ValidArgumentsLength.FileSearch;
        }

        private bool CheckThreeArguments(string[] args)
        {
            return args.Length == (int)ValidArgumentsLength.FileSearchReplace;
        }

    }
}
