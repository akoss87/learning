using System;

namespace ParseInt
{
    class Program
    {
        enum ParseState
        {
            ExpectingSignOrDigit = 0,
            PlusSignRead = 1,
            MinusSignRead = 2,
            ExpectingDigit = 3
        }

        static bool IsHexDigit(char c)
        {
            return char.IsDigit(c) || ('A' <= c && c <= 'F') || ('a' <= c && c <= 'f');
        }

        static int GetDigitValue(char c)
        {
            if (c >= 'a')
                return c - 87;

            if (c >= 'A')
                return c - 55;

            return c - '0';
        }

        static bool ProcessDigit(ref int accumulator, char c)
        {
            try
            {
                accumulator = checked(accumulator * 16 - GetDigitValue(c));
            }
            catch (OverflowException)
            {
                return false;
            }

            return true;
        }

        static bool TryParseInt32(string input, out int value)
        {
            value = 0;

            int accumulator = 0;
            bool isNegative = false;
            ParseState state = ParseState.ExpectingSignOrDigit;

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
                        else if (IsHexDigit(c))
                        {
                            if (!ProcessDigit(ref accumulator, c))
                                return false;
                            state = ParseState.ExpectingDigit;
                        }
                        else
                            return false;

                        break;
                    case ParseState.PlusSignRead:
                        if (IsHexDigit(c))
                        {
                            if (!ProcessDigit(ref accumulator, c))
                                return false;
                            state = ParseState.ExpectingDigit;
                        }
                        else
                            return false;

                        break;
                    case ParseState.MinusSignRead:
                        if (IsHexDigit(c))
                        {
                            if (!ProcessDigit(ref accumulator, c))
                                return false;
                            state = ParseState.ExpectingDigit;
                        }
                        else
                            return false;

                        break;
                    case ParseState.ExpectingDigit:
                        if (IsHexDigit(c))
                        {
                            if (!ProcessDigit(ref accumulator, c))
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

        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            //int value; 
            //if (TryParse(input, out value))
            // vagy rövidebben:
            if (TryParseInt32(input, out int value))
            {
                Console.WriteLine("A szám értéke: {0}", value);
            }
            else
            {
                Console.WriteLine("A megadott szám hibás formátumú vagy nem fér bele az Int32 típus tartományába.");
            }
        }
    }
}
