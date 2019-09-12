using Logger;
using Moq;
using System.Collections.Generic;
using Task7_8_Sequence.Factories;
using Task7_8_Sequence.Models;
using Task7_8_Sequence.Tests.IClassFixtures;
using Xunit;

namespace Task7_8_Sequence.Tests
{
    public class SequenceLimitFactory_Tests : IClassFixture<SequensLimitFactoryFixture>
    {
        private SequensLimitFactoryFixture _sequenceLimitFactory;

        public SequenceLimitFactory_Tests(SequensLimitFactoryFixture factoryFixture)
        {
            _sequenceLimitFactory = factoryFixture;
        }

        [Theory]
        [MemberData(nameof(TwoArgumentsVerifyMax))]
        public void test_Create_TakesTwoArguments_VerifyMax(string min, 
                            string max, int expectedMax)
        {
            var arguments = new string[] { min, max };

            var sequenceLimits = _sequenceLimitFactory
                                        .SequenceLimitFactory.Create(arguments);

            Assert.Equal(sequenceLimits.Max, expectedMax);
        }


        [Theory]
        [MemberData(nameof(TwoArgumentsVerifyMin))]
        public void test_Create_TakesTwoArguments_VerifyMin(string min,
                            string max, int expectedMin)
        {
            var arguments = new string[] { min, max };
            
            var sequenceLimits = _sequenceLimitFactory
                                 .SequenceLimitFactory.Create(arguments);

            Assert.Equal(sequenceLimits.Min, expectedMin);
        }
        
        public static IEnumerable<object[]> TwoArgumentsVerifyMin =>
        new List<object[]>
        {
            new object[] { "1", "20", 1 },
            new object[] { "20","1", 1 }
        };


        public static IEnumerable<object[]> TwoArgumentsVerifyMax =>
        new List<object[]>
        {
            new object[] { "1", "20", 20 },
            new object[] { "20","1", 20 }
        };


        [Theory]
        [MemberData(nameof(OneArgumentsVerifyMin))]
        public void test_Create_TakesOneArgument_VerifyMin(string max,
                                                        int expectedMin)
        {
            var arguments = new string[] { max };
            
            var sequenceLimits = _sequenceLimitFactory
                                 .SequenceLimitFactory.Create(arguments);

            Assert.Equal(sequenceLimits.Min, expectedMin);
        }



        [Theory]
        [MemberData(nameof(OneArgumentsVerifyMax))]
        public void test_Create_TakesOneArgument_ShouldReturns(string max,
                                                         int expectedMax)
        {
            var arguments = new string[] { max };


            var sequenceLimits = _sequenceLimitFactory
                                 .SequenceLimitFactory.Create(arguments);

            Assert.Equal(sequenceLimits.Max, expectedMax);
        }

        public static IEnumerable<object[]> OneArgumentsVerifyMin =>
        new List<object[]>
        {
            new object[] { "20", 0 },
        };

        public static IEnumerable<object[]> OneArgumentsVerifyMax =>
        new List<object[]>
        {
            new object[] { "20", 20 },
        };
    }
}