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
            char op;
            Console.WriteLine("Adja meg az első számot:");

            for (; ; )
            {
                string s1 = Console.ReadLine();
                bool success = int.TryParse(s1, out a);

                if (success)
                    break;
                else
                    Console.WriteLine("Hiba: Csak egész számok adhatóak meg.");
            }

            Console.WriteLine("Adja meg a műveletet:");
            while (true)
            {
                string opString = Console.ReadLine();
                if (opString.Length != 1)
                    continue;

                op = opString[0];

                if (op == '+' || op == '-' || op == '*' || op == '/')
                    break;
            }

            Console.WriteLine("Adja meg a másik számot:");

            for (; ; )
            {
                string s2 = Console.ReadLine();
                bool success = int.TryParse(s2, out b);
                if (success)
                    break;
                else
                    Console.WriteLine("Hiba: Csak egész számok adhatóak meg.");
            }

            int result;

            switch (op)
            {
                case '+':
                    result = a + b;
                    break;
                case '-':
                    result = a - b;
                    break;
                case '*':
                    result = a * b;
                    break;
                case '/':
                    try
                    {
                        result = a / b;
                    }
                    catch (DivideByZeroException)
                    {
                        Console.WriteLine("Nullával osztás nincs értelmezve.");
                        return;
                    }
                    break;
                default:
                    throw new InvalidOperationException("Elvileg erre az ágra soha nem kerülhet a végrehajtás.");
            }

            Console.WriteLine(result);
        }
    }
}
