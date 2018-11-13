using System;

namespace ParseInt
{
    static class UltimateIntParser
    {
        enum ParseState
        {
            ExpectingSignOrDigit = 0,
            PlusSignRead = 1,
            MinusSignRead = 2,
            ExpectingDigit = 3
        }

        delegate int DigitValueGetter(char c);

        static int GetBinDigitValue(char c)
        {
            if (c == '0')
                return 0;

            if (c == '1')
                return 1;

            return -1;
        }

        static int GetDecDigitValue(char c)
        {
            if (char.IsDigit(c))
                return c - '0';

            return -1;
        }

        static int GetHexDigitValue(char c)
        {
            if (char.IsDigit(c))
                return c - '0';

            if ('A' <= c && c <= 'F')
                return c - 55;

            if ('a' <= c && c <= 'f')
                return c - 87;

            return -1;
        }

        static bool ProcessDigit(ref int accumulator, int digitValue, int @base)
        {
            try
            {
                accumulator = checked(accumulator * @base - digitValue);
            }
            catch (OverflowException)
            {
                return false;
            }

            return true;
        }

        public static bool TryParse(string input, int @base, out int value)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            DigitValueGetter getDigitValue;
            switch (@base)
            {
                case 2:
                    getDigitValue = GetBinDigitValue;
                    break;
                case 10:
                    getDigitValue = GetDecDigitValue;
                    break;
                case 16:
                    getDigitValue = GetHexDigitValue;
                    break;
                default:
                    throw new ArgumentException("Base not supported.", nameof(@base));
            }

            value = 0;

            int accumulator = 0;
            bool isNegative = false;
            ParseState state = ParseState.ExpectingSignOrDigit;
            int digitValue;

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];

                switch (state)
                {
                    case ParseState.ExpectingSignOrDigit:
                        if (c == '+')
                        {
                            state = ParseState.PlusSignRead;
                        }
                        else if (c == '-')
                        {
                            isNegative = true;
                            state = ParseState.MinusSignRead;
                        }
                        else if ((digitValue = getDigitValue(c)) >= 0)
                        {
                            if (!ProcessDigit(ref accumulator, digitValue, @base))
                                return false;
                            state = ParseState.ExpectingDigit;
                        }
                        else
                            return false;

                        break;
                    case ParseState.PlusSignRead:
                        if ((digitValue = getDigitValue(c)) >= 0)
                        {
                            if (!ProcessDigit(ref accumulator, digitValue, @base))
                                return false;
                            state = ParseState.ExpectingDigit;
                        }
                        else
                            return false;

                        break;
                    case ParseState.MinusSignRead:
                        if ((digitValue = getDigitValue(c)) >= 0)
                        {
                            if (!ProcessDigit(ref accumulator, digitValue, @base))
                                return false;
                            state = ParseState.ExpectingDigit;
                        }
                        else
                            return false;

                        break;
                    case ParseState.ExpectingDigit:
                        if ((digitValue = getDigitValue(c)) >= 0)
                        {
                            if (!ProcessDigit(ref accumulator, digitValue, @base))
                                return false;
                        }
                        else
                            return false;

                        break;
                }
            }

            switch (state)
            {
                case ParseState.ExpectingDigit:
                    //if (isNegative)
                    //    value = -accumulator;
                    //else
                    //    value = accumulator;
                    // vagy rövidebben:
                    try
                    {
                        value = isNegative ? accumulator : checked(-accumulator);
                    }
                    catch (OverflowException)
                    {
                        return false;
                    }
                    return true;
                default:
                    return false;
            }
        }
    }
}
