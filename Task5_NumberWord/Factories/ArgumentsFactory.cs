using System;
using Task5_NumberWord.Enums;
using Task5_NumberWord.Factories.Interfaces;
using Task5_NumberWord.Models;

namespace Task5_NumberWord.Factories
{
    public class ArgumentsFactory : IArgumentsFactory
    {
        public Arguments Create(string[] args)
        {
            Arguments arguments = null;

            switch ((ValidArgumentsLength)args.Length)
            {
                case ValidArgumentsLength.Number:
                    arguments = new Arguments(args[0]);
                    break;

                case ValidArgumentsLength.NumberLanguage:
                    Enum.TryParse(args[1], out Language language);
                    arguments = new Arguments(args[0]);
                    break;

                default:
                    break;
            }

            return arguments;
        }
    }
}
