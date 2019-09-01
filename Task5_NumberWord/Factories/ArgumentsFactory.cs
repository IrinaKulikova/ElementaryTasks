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

            switch ((CountArgument)args.Length)
            {
                case CountArgument.Min:
                default:
                    arguments = new Arguments(args[0], Language.EU);
                    break;

                case CountArgument.Max:
                    Enum.TryParse(args[1], out Language language);
                    arguments = new Arguments(args[0], language);
                    break;
            }

            return arguments;
        }
    }
}
