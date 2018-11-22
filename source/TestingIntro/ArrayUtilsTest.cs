using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SampleLibrary
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
        public void FindEvenNumberInArray_Match()
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
        public void FindEvenNumberInArray_NoMatch()
        {
            int[] array = { 1, 5, 5, 7, 3 };

            int index = ArrayUtils.FindIndex(array, IsEven);

            Assert.Equal(-1, index);
        }

        [Fact]
        public void FindOddNumberInArray_Match()
        {
            int[] array = { 1, 4, 5, 2, 6 };

            int index = ArrayUtils.FindIndex(array, IsOdd);

            Assert.Equal(0, index);
        }

        [Fact]
        public void FindIndex_ArrayIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => ArrayUtils.FindIndex(null, IsOdd));
        }

        [Fact]
        public void FindIndex_MatchIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => ArrayUtils.FindIndex(new int[0], null));
        }
    }
}
