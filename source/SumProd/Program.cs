using System;
using System.Text;

namespace SumProd
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int part;

            while (true)
            {
                string readNum = Console.ReadLine();
                if (readNum == "")
                {
                    Console.WriteLine(sum);
                    return;
                }
                if (!int.TryParse(readNum, out part))
                {
                    Console.WriteLine("Hibás érték.");
                    return;
                }
                sum = sum + part;
            }
        }

    }
}