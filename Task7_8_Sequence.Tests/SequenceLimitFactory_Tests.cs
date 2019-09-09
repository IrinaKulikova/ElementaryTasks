using System.Collections.Generic;
using Task7_8_Sequence.Factories;
using Task7_8_Sequence.Models;
using Xunit;

namespace Task7_8_Sequence.Tests
{
    public class SequenceLimitFactory_Tests
    {
        [Theory]
        [MemberData(nameof(TwoArguments))]
        public void Create_Success(string min, string max,
                                   int expectedMin, int expectedMax)
        {
            var sequenceLimitFactory = new SequenceLimitFactory();

            var arguments = new string[] { min, max };

            var sequenceLimits = sequenceLimitFactory.Create(arguments);

            Assert.NotNull(sequenceLimits);
            Assert.IsType<SequenceLimit>(sequenceLimits);
            Assert.Equal(sequenceLimits.Max, expectedMax);
            Assert.Equal(sequenceLimits.Min, expectedMin);
        }

        public static IEnumerable<object[]> TwoArguments =>
        new List<object[]>
        {
            new object[] { "1", "20", 1, 20 },
            new object[] { "20","1", 1,20 }
        };

        [Theory]
        [MemberData(nameof(OneArguments))]
        public void CreateOneArgument_Success(string max,
                                  int expectedMin, int expectedMax)
        {
            var sequenceLimitFactory = new SequenceLimitFactory();

            var arguments = new string[] { max };

            var sequenceLimits = sequenceLimitFactory.Create(arguments);

            Assert.NotNull(sequenceLimits);
            Assert.IsType<SequenceLimit>(sequenceLimits);
            Assert.Equal(sequenceLimits.Max, expectedMax);
            Assert.Equal(sequenceLimits.Min, expectedMin);
        }

        public static IEnumerable<object[]> OneArguments =>
        new List<object[]>
        {
            new object[] { "20", 0, 20 },
        };
    }
}
