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
            for (var i = 0; i < 1000; i++)
                Assert.Equal(i, RomanNumbers.RomanToInt(RomanNumbers.IntToRoman(i)));

            Assert.Equal(1444, RomanNumbers.RomanToInt("MCDXLIV"));
            Assert.Equal(1444, RomanNumbers.RomanToInt("MCCCCXXXXIIII"));

            Assert.Equal(2999, RomanNumbers.RomanToInt("MMCMXCIX"));
            Assert.Equal(2999, RomanNumbers.RomanToInt("MMDCCCCLXXXXVIIII"));

            // TODO: rossz karaktersorozatokat generálni
            //var random = new Random();
            //const int minLength = 2;
            //const int maxLength = 12;
            //char[] chars = { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };

            //for (var i = 0; i < 10000; i++)
            //{
            //    var length = minLength + random.Next(maxLength - minLength + 1);
            //    var buffer = new char[length];
            //    for (var j = 0; j < buffer.Length; j++)
            //        buffer[j] = chars[random.Next(chars.Length)];
            //}
        }
    }
}
