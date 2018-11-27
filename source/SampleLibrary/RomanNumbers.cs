using System;
using System.Collections.Generic;
using System.Text;

namespace SampleLibrary
{
    public static class RomanNumbers
    {
        static void ProcessDigitCore(int digit, char unit, char unitX5, char unitX10, StringBuilder builder)
        {
            switch (digit)
            {
                case 1:
                    builder.Append(unit);
                    break;
                case 2:
                    builder.Append(unit, 2);
                    break;
                case 3:
                    builder.Append(unit, 3);
                    break;
                case 4:
                    builder.Append(unit).Append(unitX5);
                    break;
                case 5:
                    builder.Append(unitX5);
                    break;
                case 6:
                    builder.Append(unitX5).Append(unit);
                    break;
                case 7:
                    builder.Append(unitX5).Append(unit, 2);
                    break;
                case 8:
                    builder.Append(unitX5).Append(unit, 3);
                    break;
                case 9:
                    builder.Append(unit).Append(unitX10);
                    break;
            }
        }

        static void ProcessDigit(ref int value, int divisor, char unit, char unitX5, char unitX10, StringBuilder builder)
        {
            if (value >= divisor)
            {
                var digit = Math.DivRem(value, divisor, out value);
                ProcessDigitCore(digit, unit, unitX5, unitX10, builder);
            }
        }

        public static string IntToRoman(int value)
        {
            if (value == 0)
                return string.Empty;

            // todo: negatív számok
            if (value < 0)
                throw new ArgumentException();

            StringBuilder result = new StringBuilder();

            if (value >= 1000)
            {
                var count = Math.DivRem(value, 1000, out value);
                result.Append('M', count);
            }

            ProcessDigit(ref value, 100, 'C', 'D', 'M', result);
            ProcessDigit(ref value, 10, 'X', 'L', 'C', result);
            ProcessDigitCore(value, 'I', 'V', 'X', result);

            return result.ToString();
        }
    }
}
