using System;
using System.Text;

namespace Calc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            int a, b;
            Console.WriteLine("Adja meg az első számot:");

            do
            {
                string s1 = Console.ReadLine();
                bool success = int.TryParse(s1, out a);

                if (success)
                    break;
                else
                    Console.WriteLine("Hiba: Csak egész számok adhatóak meg.");
            }
            while (true);

            Console.WriteLine("Adja meg a másik számot:");

            do
            {
                string s2 = Console.ReadLine();
                bool success = int.TryParse(s2, out b);
                if (success)
                    break;
                else
                    Console.WriteLine("Hiba: Csak egész számok adhatóak meg.");

            }
            while (true);


            Console.WriteLine(a + b);
        }
    }
}
