using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pwgen
{
    class Program
    {
        const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string Digits = "0123456789";

        static void Main(string[] args)
        {
            int pwLength = 12;
            int pwCount = 1;
            string pwSet = Alphabet + Alphabet.ToLowerInvariant() + Digits;

            if (args.Length == 0)
            {
                WriteUsage("No arguments was supplied.");
                return;
            }

            string option = args[0].ToLowerInvariant());

            if (option == "-?" || option == "-h" || option == "/?" || option == "/h" || option == "--help")
            {
                WriteUsage();
                return;
            }

            for (int i = 0; i < args.Length - 1; i++)
            {
                option = args[i].ToLowerInvariant();

                if (option == "-l" || option == "--length")
                {
                    i++;
                    if (args.Length <= i)
                    {
                        WriteUsage("Value is missing for option length.");
                        return;
                    }

                    if (!int.TryParse(args[i], out pwLength))
                    {
                        WriteUsage("Value is invalid for option length.");
                        return;
                    }
                }
                else if (option == "-c" || option == "--count")
                {
                    i++;
                    if (args.Length <= i)
                    {
                        WriteUsage("Value is missing for option count.");
                        return;
                    }

                    if (!int.TryParse(args[i], out pwCount))
                    {
                        WriteUsage("Value is invalid for option count.");
                        return;
                    }
                }
                else
                {
                    WriteUsage($"Option '{option}' is unknown.");
                    return;
                }
            }
        }

        static void WriteUsage(string errorMessage = null)
        {
            if (errorMessage != null)
            {
                Console.WriteLine(errorMessage);
                Console.WriteLine();
            }

            Console.WriteLine("Usage:");
            Console.WriteLine("");
            Console.WriteLine("-?: Help");
            Console.WriteLine("-l, --length: Password length (default = 12)");
            Console.WriteLine("-c, --count: Password count (default = 1)");
            Console.WriteLine("-s, --set: Characters for password (default = alfanumeric)");
        }
    }
}