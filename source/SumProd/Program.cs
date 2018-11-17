using System;
using System.Text;

namespace SumProd
{
    class Program
    {
        delegate void Operation(ref int result, int value);

        static void Sum(ref int result, int value)
        {
            result += value;
        }

        static void Prod(ref int result, int value)
        {
            result *= value;
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

            switch (args[0].ToLowerInvariant())
            {
                case "sum":
                case "+":
                    result = 0;
                    operation = Sum;
                    break;
                case "prod":
                case "*":
                    result = 1;
                    operation = Prod;
                    break;
                default:
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

                operation(ref result, part);
            }

            Console.WriteLine(result);
        }
    }
}