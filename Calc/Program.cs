using System;

namespace Calc
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = Console.ReadLine();
            int a;
            bool success = int.TryParse(s1, out a);
            if (!success)
            {
                Console.WriteLine("Hiba: Csak egész számok adhatóak meg.");
                return;
            }


            string s2 = Console.ReadLine();
            int b;
            success = int.TryParse(s2, out b);
            if (!success)
            {
                Console.WriteLine("Hiba: Csak egész számok adhatóak meg.");
                return;
            }
                        
            Console.WriteLine(a + b);
        }
    }
}
