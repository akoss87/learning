using System;
using System.Text;
using System.Text.RegularExpressions;

namespace pwgen
{
    class Program
    {
        const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string Digits = "0123456789";

        static void Main(string[] args)
        {
            // "pwgen -l 8 -c 4 -s 0-9a-zA-Z"

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
                else if (option == "-s" || option == "--set")
                {
                    i++;
                    if (args.Length <= i)
                    {
                        WriteUsage("Value is missing for option character set.");
                        return;
                    }

                    pwChars = DeterminePasswordChars(args[i]);
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

        private static string DeterminePasswordChars(string pattern)
        {
            string pwChars;
            pattern = "[" + pattern + "]";
            var regex = new Regex(pattern, RegexOptions.Compiled);
            var sb = new StringBuilder();

            // a növelés nem történhet az összehasonlítás előtt,
            // mert különben túlcsordulás miatt c 0-ra változik,
            // és végtelen ciklusba esünk
            char c = char.MinValue;
            do
            {
                if (regex.IsMatch(c.ToString()))
                    sb.Append(c);
            }
            while (c++ < char.MaxValue);

            pwChars = sb.ToString();
            return pwChars;
        }

        private static void GeneratePassword(char[] buffer, string chars, Random random)
        {
            for (var j = 0; j < buffer.Length; j++)
                buffer[j] = chars[random.Next(chars.Length)];
        }

        private static void WriteUsage(string errorMessage = null)
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
            Console.WriteLine("-s, --set: Character set for password (default = alfanumeric)");
        }
    }
}