using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestingIntro
{
    public class ArrayUtilsTest
    {
        static bool IsEven(int value)
        {
            return value % 2 == 0;
        }

        static bool IsOdd(int value)
        {
            return value % 2 == 1;
        }


        [Fact]
        public void FindEvenNumberInArray()
        {
            //var array = new int[5];
            //var array = new int[] { 1, 4, 5, 2, 6 };
            //var array = new[] { 1, 4, 5, 2, 6 };
            //int[] array = new int[] { 1, 4, 5, 2, 6 };

            int[] array = { 1, 4, 5, 2, 6 };

            int index = ArrayUtils.FindIndex(array, IsEven);

            Assert.Equal(1, index);
        }

        [Fact]
        public void FindOddNumberInArray()
        {
            int[] array = { 1, 4, 5, 2, 6 };

            int index = ArrayUtils.FindIndex(array, IsOdd);

            Assert.Equal(0, index);
        }
    }
}
