using System;
using System.Collections.Generic;
using System.Text;

namespace SampleLibrary
{
    public static class RomanNumbers
    {
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

            if (value >= 100)
            {
                var digit = Math.DivRem(value, 100, out value);

                switch (digit)
                {
                    case 1:
                        result.Append('C');
                        break;
                    case 2:
                        result.Append('C', 2);
                        break;
                    case 3:
                        result.Append('C', 3);
                        break;
                    case 4:
                        result.Append('C').Append('D');
                        break;
                    case 5:
                        result.Append('D');
                        break;
                    case 6:
                        result.Append('D').Append('C');
                        break;
                    case 7:
                        result.Append('D').Append('C', 2);
                        break;
                    case 8:
                        result.Append('D').Append('C', 3);
                        break;
                    case 9:
                        result.Append('C').Append('M');
                        break;
                }
            }

            if (value >= 10)
            {
                var digit = Math.DivRem(value, 10, out value);

                switch (digit)
                {
                    case 1:
                        result.Append('X');
                        break;
                    case 2:
                        result.Append('X', 2);
                        break;
                    case 3:
                        result.Append('X', 3);
                        break;
                    case 4:
                        result.Append('X').Append('L');
                        break;
                    case 5:
                        result.Append('L');
                        break;
                    case 6:
                        result.Append('L').Append('X');
                        break;
                    case 7:
                        result.Append('L').Append('X', 2);
                        break;
                    case 8:
                        result.Append('L').Append('X', 3);
                        break;
                    case 9:
                        result.Append('X').Append('C');
                        break;
                }
            }

            switch (value)
            {
                case 1:
                    result.Append('I');
                    break;
                case 2:
                    result.Append('I', 2);
                    break;
                case 3:
                    result.Append('I', 3);
                    break;
                case 4:
                    result.Append('I').Append('V');
                    break;
                case 5:
                    result.Append('V');
                    break;
                case 6:
                    result.Append('V').Append('I');
                    break;
                case 7:
                    result.Append('V').Append('I', 2);
                    break;
                case 8:
                    result.Append('V').Append('I', 3);
                    break;
                case 9:
                    result.Append('I').Append('X');
                    break;
            }

            return result.ToString();
        }
    }
}
