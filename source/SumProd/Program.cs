using System;
using System.Text;

namespace SumProd
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 1;
            int part;
            string readNum;
            
            while (!string.IsNullOrWhiteSpace(readNum = Console.ReadLine()))
            {
                if (!int.TryParse(readNum, out part))
                {
                    Console.WriteLine("Hibás érték.");
                    continue;
                }
                sum *= part;
            }

            Console.WriteLine(sum);
        }
    }
}