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
                        else if (char.IsDigit(c))
                        {
                            accumulator = accumulator * 10 + (c - '0');
                            state = ParseState.ExpectingDigit;
                        }
                        else
                            return false;

                        break;
                    case ParseState.PlusSignRead:
                        if (char.IsDigit(c))
                        {
                            accumulator = accumulator * 10 + (c - '0');
                            state = ParseState.ExpectingDigit;
                        }
                        else
                            return false;

                        break;
                    case ParseState.MinusSignRead:
                        if (char.IsDigit(c))
                        {
                            accumulator = accumulator * 10 + (c - '0');
                            state = ParseState.ExpectingDigit;
                        }
                        else
                            return false;

                        break;
                    case ParseState.ExpectingDigit:
                        if (char.IsDigit(c))
                            accumulator = accumulator * 10 + (c - '0');
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
                    value = isNegative ? -accumulator : accumulator;
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
                Console.WriteLine("Hibás a megadott szám.");
            }
        }
    }
}
