using System;
using System.Text;

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
            string pwChars = Alphabet + Alphabet.ToLowerInvariant() + Digits;

            if (args.Length == 0)
            {
                WriteUsage("No arguments was supplied.");
                return;
            }

            string option = args[0].ToLowerInvariant();

            if (option == "-?" || option == "-h" || option == "/?" || option == "/h" || option == "--help")
            {
                WriteUsage();
                return;
            }

            for (int i = 0; i < args.Length; i++)
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

                    if (!int.TryParse(args[i], out pwLength) || pwLength < 1)
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

                    if (!int.TryParse(args[i], out pwCount) || pwCount < 1)
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

            Random random = new Random();
            var buffer = new char[pwLength];

            for (; pwCount > 0; pwCount--)
            {
                GeneratePassword(buffer, pwChars, random);
                Console.WriteLine(new string(buffer));
            }
        }

        static void GeneratePassword(char[] buffer, string chars, Random random)
        {
            for (var j = 0; j < buffer.Length; j++)
                buffer[j] = chars[random.Next(chars.Length)];
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