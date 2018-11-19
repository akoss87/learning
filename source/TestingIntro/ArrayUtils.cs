namespace TestingIntro
{
    public delegate bool Match(int value);

    public static class ArrayUtils
    {
        public static int FindIndex(int[] array, Match match)
        {
            for (int i = 0; i < array.Length; i++)
                if (match(array[i]))
                    return i;

            return -1;
        }

        // Lambda syntax: value => value % 2 == 1

        //static bool IsOdd(int value)
        //{
        //	return value % 2 == 1;
        //}
        //
        //static bool IsEven(int value)
        //{
        //	return value % 2 == 0;
        //}
        //
        //static bool IsGreaterThan10(int value)
        //{
        //	return value > 10;
        //}
        //
        //static bool IsLessThan5(int value)
        //{
        //	return value < 5;
        //}

        //static int FirstOddIndex(int[] array)
        //{
        //	for (int i = 0; i < array.Length; i++)
        //		if (array[i] % 2 == 1)
        //			return i;
        //
        //	return -1;
        //}
        //

        //static int FirstEvenIndex(int[] array)
        //{
        //	for (int i = 0; i < array.Length; i++)
        //		if (array[i] % 2 == 0)
        //			return i;
        //
        //	return -1;
        //}
        //
        //static int FirstGreaterThan10Index(int[] array)
        //{
        //	for (int i = 0; i < array.Length; i++)
        //		if (array[i] > 10)
        //			return i;
        //
        //	return -1;
        //}
        //
        //static int FirstLessThan5Index(int[] array)
        //{
        //	for (int i = 0; i < array.Length; i++)
        //		if (array[i] < 5)
        //			return i;
        //
        //	return -1;
        //}
    }
}
