﻿using Logger;
using System;
using Task4_Parser.Enums;
using Task4_Parser.Models;
using Task4_Parser.Providers;
using Task4_Parser.Services.Interfaces;

namespace Task4_Parser.Services
{
    public class ParserManager : IParserManager
    {
        #region private fields

        private readonly ILogger _logger;

        #endregion

        #region events

        public event Counter CountResult;
        public event Replacer ReplaceResult;
        public event EmptyOrErrorArguments InvalidArguments;

        #endregion

        #region ctor

        public ParserManager(ILogger logger)
        {
            _logger = logger;
        }

        #endregion

        public void Parse(IInputArguments argumentsLength)
        {
            _logger.Error("ParserManager method Parse was called!");

            switch (argumentsLength.ArgumentsLength)
            {
                case ValidArgumentsLength.Empty:
                default:
                    InvalidArguments?.Invoke();
                    _logger.Error("switch by ArgumentsLength case" +
                                    "ValidArgumentsLength.Empty.");
                    break;

                case ValidArgumentsLength.FileSearch:
                    GetCountEntries(argumentsLength);
                    break;

                case ValidArgumentsLength.FileSearchReplace:
                    GetCountEntriesAndReplace(argumentsLength);
                    break;
            }
        }


        public void GetCountEntriesAndReplace(IInputArguments arguments)
        {
            _logger.Info("ParserManager method GetCountEntriesAndReplace was called");

            using (var provider = new StreamReadWriteProvider(arguments, _logger))
            {
                var parser = new ParserReplacer();

                try
                {
                    var textResult = parser.Replace(provider.StreamWriter, provider.StreamReader,
                                                        arguments.SearchText, arguments.NewText);

                    _logger.Info("ParserManager method GetCountEntriesAndReplace " +
                                 "finished.");
                    ReplaceResult?.Invoke(textResult);
                }
                catch (NullReferenceException ex)
                {
                    InvalidArguments?.Invoke();
                    _logger.Error(ex);
                }
            }
        }


        public void GetCountEntries(IInputArguments arguments)
        {
            _logger.Info("ParserManager method GetCountEntries was called");

            using (var provider = new StreamReadProvider(arguments, _logger))
            {
                try
                {
                    var parser = new ParserCounter();

                    int count = parser.Calculate(provider.StreamReader,
                                                 arguments.SearchText);

                    _logger.Info("ParserManager method GetCountEntries returned "
                                  + count);

                    CountResult?.Invoke(count);
                }
                catch (NullReferenceException ex)
                {
                    InvalidArguments?.Invoke();
                    _logger.Error(ex);
                }
            }
        }
    }
}