using System.Collections.Generic;
using Task7_8_Sequence.Sequences;
using Task7_8_Sequence.Models;
using Xunit;

namespace Task7_8_Sequence.Tests
{
    public class FinonacciSequence_Tests
    {
        [Theory]
        [MemberData(nameof(ArgumentsFibonacciSequence))]
        public void test_Create_FibonacciSequence_VerifyCollectionItems
                                                   (int min, int max, 
                                                   IEnumerable<int> excpected)
        {
            var limits = new SequenceLimit(min, max);
            var sequence = new FibonacciSequence(limits);

            Assert.Equal(sequence, excpected);
        }

        public static IEnumerable<object[]> ArgumentsFibonacciSequence =>
        new List<object[]>
        {
            new object[] { 1, 20, new List<int>() { 1, 1, 2, 3, 5, 8, 13 } },
            new object[] { 10, 30, new List<int>() { 13 , 21 } },
        };
    }
}
