using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SampleLibrary
{
    public class UltimateIntParserTest
    {
        [Fact]
        public void ParsingBinaryNumber()
        {
            bool success = UltimateIntParser.TryParse("1011", 2, out int value);

            Assert.True(success);
            Assert.Equal(0b1011, value);
        }

        [Fact]
        public void ParsingDecimalNumber()
        {
            bool success = UltimateIntParser.TryParse("1234567890", 10, out int value);

            Assert.True(success);
            Assert.Equal(1234567890, value);
        }

        [Fact]
        public void ParsingHexadecimalNumber()
        {
            bool success = UltimateIntParser.TryParse("23456789", 16, out int value);

            Assert.True(success);
            Assert.Equal(0x23456789, value);

            success = UltimateIntParser.TryParse("01abcdef", 16, out value);

            Assert.True(success);
            Assert.Equal(0x01abcdef, value);
        }
    }
}
