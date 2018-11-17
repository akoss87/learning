using System;
using System.Text;

namespace SumProd
{
    class Program
    {
        delegate int Operation(int a, int b);

        static int Sum(int a, int b)
        {
            return a + b;
        }

        static int Prod(int a, int b)
        {
            return a * b;
        }

        static void Main(string[] args)
        {
            if (args.Length <= 0)
            {
                Console.Error.WriteLine("Legalább 1 paramétert meg kell adni.");
                return;
            }

            int result;
            Operation operation;
            if ((args[0] == "sum") || (args[0] == "+"))
            {
                result = 0;
                operation = Sum;
            }
            else if ((args[0] == "prod") || (args[0] == "*"))
            {
                result = 1;
                operation = Prod;
            }
            else
            {
                Console.Error.WriteLine("Hibás érték.");
                return;
            }

            int part;
            string readNum;

            while (!string.IsNullOrWhiteSpace(readNum = Console.ReadLine()))
            {
                if (!int.TryParse(readNum, out part))
                {
                    Console.Error.WriteLine("Hibás érték.");
                    continue;
                }

                result = operation(result, part);
            }

            Console.WriteLine(result);
        }
    }
}