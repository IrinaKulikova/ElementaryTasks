﻿using CustomCollections;
using DIResolver;
using Logger;
using System;
using Task4_Parser.Enums;
using Task4_Parser.Factories.Interfaces;
using Task4_Parser.Models;
using Task4_Parser.Services.Interfaces;

namespace Task4_Parser
{
    public class Application : IApplication
    {
        readonly IArgumentsValidator argumentsValidator = null;
        readonly IParserManager parserManager = null;
        readonly ILogger logger = null;
        readonly IParseArgumentsFactory parseArgumentsFactory = null;

        public Application(IArgumentsValidator argumentsValidator,
                           IParserManager parserManager,
                           ILogger logger,
                           IParseArgumentsFactory parseArgumentsFactory)
        {
            this.argumentsValidator = argumentsValidator;
            this.parserManager = parserManager;
            this.logger = logger;
            this.parseArgumentsFactory = parseArgumentsFactory;
        }

        public void Start(string[] args)
        {
            if (!argumentsValidator.Check(args))
            {
                logger.Warning("Invalid arguments: " + string.Join(", ", args));
            }

            if (argumentsValidator.Check(args))
            {
                IArgumentCollection<string> argumentsCollection = new ArgumentCollection<string>(args);
                IParser parser = parserManager.GetParser((ValidArgumentsLength)argumentsCollection.Count);
                ParseArguments parseArguments = parseArgumentsFactory.Create(argumentsCollection);
                int count = parser.RunText(parseArguments);
                Console.WriteLine(count);
                Console.ReadKey();
            }
            else
            {
                logger.Warning("End of program. Invalid arguments twice " + string.Join(", ", args));
            }
        }
    }
}