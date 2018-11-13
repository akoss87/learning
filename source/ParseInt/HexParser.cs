using System;
using System.Collections.Generic;
using System.Text;

namespace ParseInt
{
    static class HexParser
    {
        enum ParseState
        {
            ExpectingSignOrDigit = 0,
            PlusSignRead = 1,
            MinusSignRead = 2,
            ExpectingDigit = 3
        }

        static int GetDigitValue(char c)
        {
            if (char.IsDigit(c))
                return c - '0';

            if ('A' <= c && c <= 'F')
                return c - 55;

            if ('a' <= c && c <= 'f')
                return c - 87;

            return -1;
        }

        static bool ProcessDigit(ref int accumulator, int digitValue)
        {
            try
            {
                accumulator = checked(accumulator * 16 - digitValue);
            }
            catch (OverflowException)
            {
                return false;
            }

            return true;
        }

        public static bool TryParse(string input, out int value)
        {
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
                        else if ((digitValue = GetDigitValue(c)) >= 0)
                        {
                            if (!ProcessDigit(ref accumulator, digitValue))
                                return false;
                            state = ParseState.ExpectingDigit;
                        }
                        else
                            return false;

                        break;
                    case ParseState.PlusSignRead:
                        if ((digitValue = GetDigitValue(c)) >= 0)
                        {
                            if (!ProcessDigit(ref accumulator, digitValue))
                                return false;
                            state = ParseState.ExpectingDigit;
                        }
                        else
                            return false;

                        break;
                    case ParseState.MinusSignRead:
                        if ((digitValue = GetDigitValue(c)) >= 0)
                        {
                            if (!ProcessDigit(ref accumulator, digitValue))
                                return false;
                            state = ParseState.ExpectingDigit;
                        }
                        else
                            return false;

                        break;
                    case ParseState.ExpectingDigit:
                        if ((digitValue = GetDigitValue(c)) >= 0)
                        {
                            if (!ProcessDigit(ref accumulator, digitValue))
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
