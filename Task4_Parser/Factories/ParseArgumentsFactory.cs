﻿using System;
using CustomCollections;
using Logger;
using Task4_Parser.Factories.Interfaces;
using Task4_Parser.Models;

namespace Task4_Parser.Factories
{
    public class ParseArgumentsFactory : IParseArgumentsFactory
    {
        ILogger logger = null;

        public ParseArgumentsFactory(ILogger logger)
        {
            this.logger = logger;
        }

        public ParseArguments Create(IArgumentCollection<string> collection)
        {
            var filePath = collection[0];
            var searchText = collection[1];
            string newText = null;
            try
            {
                newText = collection[2];
            }
            catch (IndexOutOfRangeException ex)
            {
                logger.Error(ex);
            }

            return new ParseArguments(filePath, searchText, newText);
        }
    }
}