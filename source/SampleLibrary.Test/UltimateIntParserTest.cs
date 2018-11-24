using System;
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

        [Fact]
        public void ParsingNumberWithSign()
        {
            bool success = UltimateIntParser.TryParse("-567", 10, out int value);

            Assert.True(success);
            Assert.Equal(-567, value);

            success = UltimateIntParser.TryParse("+765", 10, out value);

            Assert.True(success);
            Assert.Equal(765, value);
        }

        [Fact]
        public void WrongArguments()
        {
            Assert.Throws<ArgumentNullException>(() => UltimateIntParser.TryParse(null, 10, out int value));

            Assert.Throws<ArgumentException>(() => UltimateIntParser.TryParse("121", 17, out int value));
        }

        [Fact]
        public void NumberOverflows()
        {
            bool success = UltimateIntParser.TryParse("7fffffff", 16, out int value);

            Assert.True(success);
            Assert.Equal(0x7fff_ffff, value);

            success = UltimateIntParser.TryParse("80000000", 16, out value);

            Assert.False(success);

            success = UltimateIntParser.TryParse("-80000000", 16, out value);

            Assert.True(success);
            Assert.Equal(-0x8000_0000, value);

            success = UltimateIntParser.TryParse("-80000001", 16, out value);

            Assert.False(success);
        }

        [Fact]
        public void WrongInputFormat()
        {
            // megállás
            bool success = UltimateIntParser.TryParse("", 16, out int value);

            Assert.False(success);

            success = UltimateIntParser.TryParse("+", 16, out value);

            Assert.False(success);

            success = UltimateIntParser.TryParse("-", 16, out value);

            // értelmezhetetlen karakter
            Assert.False(success);

            success = UltimateIntParser.TryParse("=", 16, out value);

            Assert.False(success);

            success = UltimateIntParser.TryParse("++", 16, out value);

            Assert.False(success);

            success = UltimateIntParser.TryParse("--", 16, out value);

            Assert.False(success);

            success = UltimateIntParser.TryParse("D87+", 16, out value);

            Assert.False(success);

            // értelmezhetetlen számjegy

            success = UltimateIntParser.TryParse("102", 2, out value);

            Assert.False(success);

            success = UltimateIntParser.TryParse("10A", 10, out value);

            Assert.False(success);

            success = UltimateIntParser.TryParse("10G", 16, out value);

            Assert.False(success);
        }
    }
}
