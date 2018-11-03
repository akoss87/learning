using System;

namespace Calc
{
    class Program
    {
        static void Main(string[] args)
        {
            string num1 = Console.ReadLine();
            int a = int.Parse(num1);

            string num2 = Console.ReadLine();
            int b = int.Parse(num2);

            Console.WriteLine(a + b);
        }
    }
}
