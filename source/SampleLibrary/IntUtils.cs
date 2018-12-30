using System;
using System.Collections.Generic;
using System.Text;

namespace SampleLibrary
{
    public static class IntUtils
    {
        static readonly int[] s_powersOfTen = new int[10] { 1, 10, 100, 1_000, 10_000, 100_000, 1_000_000, 10_000_000, 100_000_000, 1_000_000_000 };

        public static int ToIntSafe(double x)
        {
            return checked((int)x);
        }

        public static int Round(int value, int digits)
        {
            if (digits < 0 || digits > 9)
                throw new ArgumentOutOfRangeException(nameof(digits));

            if (digits == 0)
                return value;

            var power = s_powersOfTen[digits];
            var halfOfPower = power / 2;

            value = Math.DivRem(value, power, out int remainder);
            if (remainder >= halfOfPower)
                value++;
            else if (-remainder >= halfOfPower)
                value--;

            checked { value *= power; }

            return value;
        }
    }
}
