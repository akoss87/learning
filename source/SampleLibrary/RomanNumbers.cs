using System;
using System.Text;

namespace SampleLibrary
{
    public static class RomanNumbers
    {
        enum ParseState
        {
            Initial,
            IRead,
            IIRead,
            IIIRead,
            IIIIRead,
            IVRead,
            IXRead,
            VRead,
            VIRead,
            VIIRead,
            VIIIRead,
            VIIIIRead,
        }

        static readonly byte[] s_numberLengths = { 0, 1, 2, 3, 2, 1, 2, 3, 4, 2 };

        static readonly Action<StringBuilder, char, char, char>[] s_digitAppenders =
        {
            (builder, unit, unitX5, unitX10) => { },
            (builder, unit, unitX5, unitX10) => builder.Append(unit),
            (builder, unit, unitX5, unitX10) => builder.Append(unit,2),
            (builder, unit, unitX5, unitX10) => builder.Append(unit,3),
            (builder, unit, unitX5, unitX10) => builder.Append(unit).Append(unitX5),
            (builder, unit, unitX5, unitX10) => builder.Append(unitX5),
            (builder, unit, unitX5, unitX10) => builder.Append(unitX5).Append(unit),
            (builder, unit, unitX5, unitX10) => builder.Append(unitX5).Append(unit, 2),
            (builder, unit, unitX5, unitX10) => builder.Append(unitX5).Append(unit, 3),
            (builder, unit, unitX5, unitX10) => builder.Append(unit).Append(unitX10),
        };

        public static string IntToRoman(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            if (value == 0)
                return string.Empty;

            int thousandsCount = value >= 1000 ? Math.DivRem(value, 1000, out value) : 0;
            int hundredsDigit = value >= 100 ? Math.DivRem(value, 100, out value) : 0;
            int tensDigit = value >= 10 ? Math.DivRem(value, 10, out value) : 0;

            int numberLength = thousandsCount + s_numberLengths[hundredsDigit] + s_numberLengths[tensDigit] + s_numberLengths[value];

            StringBuilder result = new StringBuilder(numberLength);

            result.Append('M', thousandsCount);
            s_digitAppenders[hundredsDigit](result, 'C', 'D', 'M');
            s_digitAppenders[tensDigit](result, 'X', 'L', 'C');
            s_digitAppenders[value](result, 'I', 'V', 'X');

            return result.ToString();
        }

        public static bool TryParseRoman(string input, out int value)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            value = 0;
            ParseState currentState = ParseState.Initial;

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];

                switch (currentState)
                {
                    case ParseState.Initial:
                        if (c == 'I')
                        {
                            currentState = ParseState.IRead;
                        }
                        else if (c == 'V')
                        {
                            currentState = ParseState.VRead;
                        }
                        else
                            return false;
                        break;
                    case ParseState.IRead:
                        if (c == 'I')
                        {
                            currentState = ParseState.IIRead;
                        }
                        else if (c == 'V')
                        {
                            currentState = ParseState.IVRead;
                        }
                        else if (c == 'X')
                        {
                            currentState = ParseState.IXRead;
                        }
                        else
                            return false;
                        break;
                    case ParseState.IIRead:
                        if (c == 'I')
                        {
                            currentState = ParseState.IIIRead;
                        }
                        else
                            return false;
                        break;
                    case ParseState.IIIRead:
                        if (c == 'I')
                        {
                            currentState = ParseState.IIIIRead;
                        }
                        else
                            return false;
                        break;
                    case ParseState.VRead:
                        if (c == 'I')
                        {
                            currentState = ParseState.VIRead;
                        }
                        else
                            return false;
                        break;
                    case ParseState.VIRead:
                        if (c == 'I')
                        {
                            currentState = ParseState.VIIRead;
                        }
                        else
                            return false;
                        break;
                    case ParseState.VIIRead:
                        if (c == 'I')
                        {
                            currentState = ParseState.VIIIRead;
                        }
                        else
                            return false;
                        break;
                    case ParseState.VIIIRead:
                        if (c == 'I')
                        {
                            currentState = ParseState.VIIIIRead;
                        }
                        else
                            return false;
                        break;
                    case ParseState.IVRead:
                    case ParseState.IXRead:
                    case ParseState.IIIIRead:
                    case ParseState.VIIIIRead:
                        return false;
                }
            }

            switch (currentState)
            {
                case ParseState.Initial:
                    value = 0;
                    return true;
                case ParseState.IRead:
                    value = 1;
                    return true;
                case ParseState.IIRead:
                    value = 2;
                    return true;
                case ParseState.IIIRead:
                    value = 3;
                    return true;
                case ParseState.IIIIRead:
                case ParseState.IVRead:
                    value = 4;
                    return true;
                case ParseState.VRead:
                    value = 5;
                    return true;
                case ParseState.VIRead:
                    value = 6;
                    return true;
                case ParseState.VIIRead:
                    value = 7;
                    return true;
                case ParseState.VIIIRead:
                    value = 8;
                    return true;
                case ParseState.VIIIIRead:
                case ParseState.IXRead:
                    value = 9;
                    return true;
                default:
                    // NB: execution should never get here
                    throw new InvalidOperationException();
            }
        }

        public static int RomanToInt(string input)
        {
            return TryParseRoman(input, out int value) ? value : throw new FormatException();
        }
    }
}
