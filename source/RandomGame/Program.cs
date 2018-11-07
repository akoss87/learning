using System;
using System.Text;

namespace RandomGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            var random = new Random();
            int randomNumber = random.Next(100);
            Console.WriteLine("Gondoltam egy számra 0 és 99 között.");
            Console.WriteLine("Találd ki, melyik az: ");

            while (true)
            {
                string numString = Console.ReadLine();
                int numInt = 0;
                if (int.TryParse(numString, out numInt))
                {
                    if (numInt < randomNumber)
                        Console.WriteLine("Nem jó. Kisebb a megadott szám, mint a kigondolt.");
                    else if (numInt > randomNumber)
                        Console.WriteLine("Nem jó. Nagyobb a megadott szám, mint a kigondolt.");
                    else
                    {
                        Console.WriteLine("Eltaláltad a kigondolt számot.");
                        break;
                    }
                }
                else
                    Console.WriteLine("Hibás számot adtál meg.");
            }
        }
    }
}
