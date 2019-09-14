using System.Collections.Generic;
using Task7_8_Sequence.Tests.IClassFixtures;
using Xunit;

namespace Task7_8_Sequence.Tests
{
    public class SequenceLimitFactoryTests : IClassFixture<SequensLimitFactoryFixture>
    {
        private SequensLimitFactoryFixture _sequenceLimitFactory;

        public SequenceLimitFactoryTests(SequensLimitFactoryFixture factoryFixture)
        {
            _sequenceLimitFactory = factoryFixture;
        }

        [Theory]
        [MemberData(nameof(TwoArgumentsVerifyMax))]
        public void SequensLimitFactory_WithTwoArguments_VerifyReturnedInstanceMax(
                                            string min, string max, int expectedMax)
        {
            var arguments = new string[] { min, max };

            var sequenceLimits = _sequenceLimitFactory
                                        .SequenceLimitFactory.Create(arguments);

            Assert.Equal(sequenceLimits.Max, expectedMax);
        }


        [Theory]
        [MemberData(nameof(TwoArgumentsVerifyMin))]
        public void SequensLimitFactory_WithTwoArguments_VerifyReturnedInstanceMin(
                                        string min, string max, int expectedMin)
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
        public void SequensLimitFactory_WithOneArguments_VerifyReturnedInstanceMin(
                                                    string max, int expectedMin)
        {
            var arguments = new string[] { max };

            var sequenceLimits = _sequenceLimitFactory
                                 .SequenceLimitFactory.Create(arguments);

            Assert.Equal(sequenceLimits.Min, expectedMin);
        }



        [Theory]
        [MemberData(nameof(OneArgumentsVerifyMax))]
        public void SequensLimitFactory_WithOneArguments_VerifyReturnedInstanceMax(
                                                    string max, int expectedMax)
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


        [Theory]
        [InlineData(null)]
        public void SequensLimitFactory_WithNullArguments_ShoulReturnsNull(
                                                        params string[] limits)
        {
            var sequenceLimits = _sequenceLimitFactory
                                 .SequenceLimitFactory.Create(limits);

            Assert.Null(sequenceLimits);
        }


        [Theory]
        [InlineData("5", "60", "80")]
        public void SequensLimitFactory_WithTooManyArguments_ShoulReturnsNull(
                                                        params string[] limits)
        {
            var sequenceLimits = _sequenceLimitFactory
                                 .SequenceLimitFactory.Create(limits);

            Assert.Null(sequenceLimits);
        }
    }
}