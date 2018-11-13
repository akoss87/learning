using System;

namespace ParseInt
{
    static class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            //int value; 
            //if (TryParse(input, out value))
            // vagy rövidebben:
            if (UltimateIntParser.TryParse(input, 2, out int value))
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
