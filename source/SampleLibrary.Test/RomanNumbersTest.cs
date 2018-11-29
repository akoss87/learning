using System;
using Xunit;

namespace SampleLibrary
{
    public class RomanNumbersTest
    {
        [Fact]
        public void IntToRomanTest()
        {
            Assert.Equal("", RomanNumbers.IntToRoman(0));

            Assert.Equal("I", RomanNumbers.IntToRoman(1));
            Assert.Equal("II", RomanNumbers.IntToRoman(2));
            Assert.Equal("III", RomanNumbers.IntToRoman(3));
            Assert.Equal("IV", RomanNumbers.IntToRoman(4));
            Assert.Equal("V", RomanNumbers.IntToRoman(5));
            Assert.Equal("VI", RomanNumbers.IntToRoman(6));
            Assert.Equal("VII", RomanNumbers.IntToRoman(7));
            Assert.Equal("VIII", RomanNumbers.IntToRoman(8));
            Assert.Equal("IX", RomanNumbers.IntToRoman(9));

            Assert.Equal("X", RomanNumbers.IntToRoman(10));
            Assert.Equal("XX", RomanNumbers.IntToRoman(20));
            Assert.Equal("XXX", RomanNumbers.IntToRoman(30));
            Assert.Equal("XL", RomanNumbers.IntToRoman(40));
            Assert.Equal("L", RomanNumbers.IntToRoman(50));
            Assert.Equal("LX", RomanNumbers.IntToRoman(60));
            Assert.Equal("LXX", RomanNumbers.IntToRoman(70));
            Assert.Equal("LXXX", RomanNumbers.IntToRoman(80));
            Assert.Equal("XC", RomanNumbers.IntToRoman(90));

            Assert.Equal("C", RomanNumbers.IntToRoman(100));
            Assert.Equal("CC", RomanNumbers.IntToRoman(200));
            Assert.Equal("CCC", RomanNumbers.IntToRoman(300));
            Assert.Equal("CD", RomanNumbers.IntToRoman(400));
            Assert.Equal("D", RomanNumbers.IntToRoman(500));
            Assert.Equal("DC", RomanNumbers.IntToRoman(600));
            Assert.Equal("DCC", RomanNumbers.IntToRoman(700));
            Assert.Equal("DCCC", RomanNumbers.IntToRoman(800));
            Assert.Equal("CM", RomanNumbers.IntToRoman(900));

            Assert.Equal("M", RomanNumbers.IntToRoman(1000));
            Assert.Equal("MMMMM", RomanNumbers.IntToRoman(5000));

            Assert.Equal("MMXVIII", RomanNumbers.IntToRoman(2018));
            Assert.Equal("MMCCCLXV", RomanNumbers.IntToRoman(2365));

            Assert.Throws<ArgumentOutOfRangeException>(() => RomanNumbers.IntToRoman(-1));
        }

        [Fact]
        public void RomanToIntTest()
        {
            Assert.Equal(0, RomanNumbers.RomanToInt(""));

            Assert.Equal(1, RomanNumbers.RomanToInt("I"));
            Assert.Equal(2, RomanNumbers.RomanToInt("II"));
            Assert.Equal(3, RomanNumbers.RomanToInt("III"));
            Assert.Equal(4, RomanNumbers.RomanToInt("IV"));
            Assert.Equal(4, RomanNumbers.RomanToInt("IIII"));
            Assert.Equal(5, RomanNumbers.RomanToInt("V"));
            Assert.Equal(6, RomanNumbers.RomanToInt("VI"));
            Assert.Equal(7, RomanNumbers.RomanToInt("VII"));
            Assert.Equal(8, RomanNumbers.RomanToInt("VIII"));
            Assert.Equal(9, RomanNumbers.RomanToInt("IX"));
            Assert.Equal(9, RomanNumbers.RomanToInt("VIIII"));
        }
    }
}
