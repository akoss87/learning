using System;
using System.Text;

namespace SumProd
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length <= 0)
            {
                Console.Error.WriteLine("Legalább 1 paramétert meg kell adni.");
                return;
            }

            int result;
            if (args[0] == "sum")
                result = 0;
            else if (args[0] == "prod")
                result = 1;
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
                if (args[0] == "sum")
                    result += part;
                else if (args[0] == "prod")
                    result *= part;
            }

            Console.WriteLine(result);
        }
    }
}