using System;
using System.Collections.Generic;
using System.Text;

namespace SampleLibrary
{
    public static class IntUtils
    {
        public static int ToIntSafe(double x)
        {
            return checked((int)x);
        }

        public static int RoundToTens(int value)
        {
            //return checked((int)Math.Round(x/10.0, MidpointRounding.AwayFromZero) * 10);

            value = Math.DivRem(value, 10, out var lastDigit);

            if (lastDigit >= 5)
                value++;
            else if (lastDigit <= -5)
                value--;

            checked { value *= 10; }

            return value;
        }
    }
}
