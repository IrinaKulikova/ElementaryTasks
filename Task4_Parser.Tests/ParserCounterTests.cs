﻿using System;
using Task4_Parser.Services;
using Xunit;

namespace Task4_Parser.Tests
{
    public class ParserCounterTests : IClassFixture<MockStearmReader>
    {
        private MockStearmReader _mockStearmReader;

        public ParserCounterTests(MockStearmReader mockStearmReader)
        {
            _mockStearmReader = mockStearmReader;
        }

        [Theory]
        [InlineData("sit", 3)]
        public void ParserCounter_WithValidArguments_ShouldReturnsCount
                                            (string search, int expectedCount)
        {
            var parser = new ParserCounter(_mockStearmReader.StreamReader);

            int countResult = parser.Calculate(search);

            Assert.Equal(countResult, expectedCount);
        }

        [Fact]
        public void ParserCounter_WithNullStreamArgument_ShouldThrowNullReferenceException()
        {
            var parser = new ParserCounter(null);

            var searchText = "text";

            Assert.Throws<NullReferenceException>(() => parser.Calculate(searchText));
        }
    }
}
