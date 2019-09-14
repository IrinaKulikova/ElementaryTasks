using System.Collections.Generic;
using Task7_8_Sequence.Sequences;
using Task7_8_Sequence.Models;
using Xunit;

namespace Task7_8_Sequence.Tests
{
    public class SquareSequenceTests
    {
        [Theory]
        [MemberData(nameof(ArgumentsSquareSequence))]
        public void SquareSequence_WithMinMaxLimits_VerifyCollectionItems
                                (int min, int max, IEnumerable<int> excpected)
        {
            var limits = new SequenceLimit(min, max);
            IEnumerable<int> sequence = new SquareSequence(limits);

            Assert.Equal(sequence, excpected);
        }

        public static IEnumerable<object[]> ArgumentsSquareSequence =>
        new List<object[]>
        {
            new object[] { 0, 144, new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 } },
            new object[] { 0, 9, new List<int>() { 1, 2 } },
        };
    }
}
