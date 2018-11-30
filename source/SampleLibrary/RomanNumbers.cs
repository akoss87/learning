using System;
using System.Text;

namespace SampleLibrary
{
    public static class RomanNumbers
    {
        enum ParseState
        {
            Initial,
            OneUnitRead,
            TwoUnitsRead,
            ThreeUnitsRead,
            FourUnitsRead,
            UnitAndUnitX5Read,
            UnitAndUnitX10Read,
            UnitX5Read,
            UnitX5AndOneUnitRead,
            UnitX5AndTwoUnitsRead,
            UnitX5AndThreeUnitsRead,
            UnitX5AndFourUnitsRead,
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

        static void ParseRomanDigit(string input, ref int index, ref int accumulator, char unit, char unitX5, char unitX10, int unitValue)
        {
            ParseState currentState = ParseState.Initial;

            for (; index < input.Length; index++)
            {
                char c = input[index];
                if (c >= 'a')
                    c = (char)(c - 0x20);

                switch (currentState)
                {
                    case ParseState.Initial:
                        if (c == unit)
                            currentState = ParseState.OneUnitRead;
                        else if (c == unitX5)
                            currentState = ParseState.UnitX5Read;
                        else
                            goto EndOfLoop;
                        break;
                    case ParseState.OneUnitRead:
                        if (c == unit)
                            currentState = ParseState.TwoUnitsRead;
                        else if (c == unitX5)
                            currentState = ParseState.UnitAndUnitX5Read;
                        else if (c == unitX10)
                            currentState = ParseState.UnitAndUnitX10Read;
                        else
                            goto EndOfLoop;
                        break;
                    case ParseState.TwoUnitsRead:
                        if (c == unit)
                            currentState = ParseState.ThreeUnitsRead;
                        else
                            goto EndOfLoop;
                        break;
                    case ParseState.ThreeUnitsRead:
                        if (c == unit)
                            currentState = ParseState.FourUnitsRead;
                        else
                            goto EndOfLoop;
                        break;
                    case ParseState.UnitX5Read:
                        if (c == unit)
                            currentState = ParseState.UnitX5AndOneUnitRead;
                        else
                            goto EndOfLoop;
                        break;
                    case ParseState.UnitX5AndOneUnitRead:
                        if (c == unit)
                            currentState = ParseState.UnitX5AndTwoUnitsRead;
                        else
                            goto EndOfLoop;
                        break;
                    case ParseState.UnitX5AndTwoUnitsRead:
                        if (c == unit)
                            currentState = ParseState.UnitX5AndThreeUnitsRead;
                        else
                            goto EndOfLoop;
                        break;
                    case ParseState.UnitX5AndThreeUnitsRead:
                        if (c == unit)
                            currentState = ParseState.UnitX5AndFourUnitsRead;
                        else
                            goto EndOfLoop;
                        break;
                    case ParseState.UnitAndUnitX5Read:
                    case ParseState.UnitAndUnitX10Read:
                    case ParseState.FourUnitsRead:
                    case ParseState.UnitX5AndFourUnitsRead:
                        goto EndOfLoop;
                }
            }
            EndOfLoop:

            switch (currentState)
            {
                case ParseState.Initial:
                    return;
                case ParseState.OneUnitRead:
                    accumulator += unitValue;
                    return;
                case ParseState.TwoUnitsRead:
                    accumulator += 2 * unitValue;
                    return;
                case ParseState.ThreeUnitsRead:
                    accumulator += 3 * unitValue;
                    return;
                case ParseState.FourUnitsRead:
                case ParseState.UnitAndUnitX5Read:
                    accumulator += 4 * unitValue;
                    return;
                case ParseState.UnitX5Read:
                    accumulator += 5 * unitValue;
                    return;
                case ParseState.UnitX5AndOneUnitRead:
                    accumulator += 6 * unitValue;
                    return;
                case ParseState.UnitX5AndTwoUnitsRead:
                    accumulator += 7 * unitValue;
                    return;
                case ParseState.UnitX5AndThreeUnitsRead:
                    accumulator += 8 * unitValue;
                    return;
                case ParseState.UnitX5AndFourUnitsRead:
                case ParseState.UnitAndUnitX10Read:
                    accumulator += 9 * unitValue;
                    return;
                default:
                    // NB: execution should never get here
                    throw new InvalidOperationException();
            }
        }

        public static bool TryParseRoman(string input, out int value)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            int accumulator = 0;

            int index = 0;
            for (; index < input.Length; index++)
            {
                var c = input[index];
                if (c >= 'a')
                    c = (char)(c - 0x20);

                if (c == 'M')
                    accumulator += 1000;
                else
                    break;
            }

            if (index < input.Length)
            {
                ParseRomanDigit(input, ref index, ref accumulator, 'C', 'D', 'M', 100);

                if (index < input.Length)
                {
                    ParseRomanDigit(input, ref index, ref accumulator, 'X', 'L', 'C', 10);

                    if (index < input.Length)
                    {
                        ParseRomanDigit(input, ref index, ref accumulator, 'I', 'V', 'X', 1);

                        if (index < input.Length)
                        {
                            value = default;
                            return false;
                        }
                    }
                }
            }

            value = accumulator;
            return true;
        }

        public static int RomanToInt(string input)
        {
            return TryParseRoman(input, out int value) ? value : throw new FormatException();
        }
    }
}
