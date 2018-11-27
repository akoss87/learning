using System;
using System.Text;

namespace SampleLibrary
{
    public static class RomanNumbers
    {
        static readonly int[] s_numberLengths = { 0, 1, 2, 3, 2, 1, 2, 3, 4, 2 };

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
            if (value == 0)
                return string.Empty;

            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

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
    }
}
