using System;
using Xunit;

namespace SampleLibrary
{
    public class IntUtilsTest
    {
        [Fact]
        public void Round_Trivial()
        {
            var result = IntUtils.Round(255, 0);
            Assert.Equal(255, result);

            result = IntUtils.Round(-255, 0);
            Assert.Equal(-255, result);
        }

        [Fact]
        public void Round_PositiveDown()
        {
            for (int x = 250; x <= 254; x++)
            {
                var result = IntUtils.Round(x, 1);
                Assert.Equal(250, result);
            }
        }

        [Fact]
        public void Round_PositiveUp()
        {
            for (int x = 255; x <= 259; x++)
            {
                var result = IntUtils.Round(x, 1);
                Assert.Equal(260, result);
            }
        }

        [Fact]
        public void Round_NegativeUp()
        {
            for (int x = -34; x <= -30; x++)
            {
                var result = IntUtils.Round(x, 1);
                Assert.Equal(-30, result);
            }
        }

        [Fact]
        public void Round_NegativeDown()
        {
            for (int x = -39; x <= -35; x++)
            {
                var result = IntUtils.Round(x, 1);
                Assert.Equal(-40, result);
            }
        }

        [Fact]
        public void Round_Digits()
        {
            int[] expectedValues = new int[10] 
            {
                1_234_567_890,
                1_234_567_890,
                1_234_567_900,
                1_234_568_000,
                1_234_570_000,
                1_234_600_000,
                1_235_000_000,
                1_230_000_000,
                1_200_000_000,
                1_000_000_000,
            };

            for (int digits = 0; digits <= 9; digits++)
            {
                var result = IntUtils.Round(1_234_567_890, digits);
                Assert.Equal(expectedValues[digits], result);
            }
        }

        [Fact]
        public void Round_EdgeCases()
        {
            Assert.Equal(-2147483600, IntUtils.Round(int.MinValue, 2));
            Assert.Throws<OverflowException>(() => IntUtils.Round(int.MinValue, 1));

            Assert.Equal(2147483600, IntUtils.Round(int.MaxValue, 2));
            Assert.Throws<OverflowException>(() => IntUtils.Round(int.MaxValue, 1));
        }

        [Fact]
        public void Round_InvalidDigits()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => IntUtils.Round(123, -1));
            Assert.Throws<ArgumentOutOfRangeException>(() => IntUtils.Round(123, 10));
        }
    }
}
