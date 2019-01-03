using System;
using System.ComponentModel;
using System.Reflection;

using static ScaleTrainer.Interval;
using static ScaleTrainer.DiatonicMode;

namespace ScaleTrainer
{
    class Program
    {
        static readonly int[] s_majorScaleIntervals = new int[7] { MajorSecond, MajorSecond, MinorSecond, MajorSecond, MajorSecond, MajorSecond, MinorSecond };

        static readonly string[] s_notesSharp = new string[12] { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
        static readonly string[] s_notesFlat = new string[12] { "C", "Db", "D", "Eb", "E", "F", "Gb", "G", "Ab", "A", "Bb", "B" };

        static void Main(string[] args)
        {
            if (args.Length > 0)
                switch (args[0].ToLowerInvariant())
                {
                    case "--print-majors":
                        PrintDiatonicScales(Ionian);
                        break;
                    case "--print-minors":
                        PrintDiatonicScales(Aeolian);
                        break;
                }
        }

        static void Transpose(ref int noteIndex, int interval)
        {
            // kis tercet lép felfelé
            //var noteIndex = 11;
            //noteIndex += 3;
            //if (noteIndex >= s_notesSharp.Length)
            //    noteIndex -= s_notesSharp.Length;

            // kvartot lép lefelé
            //noteIndex = 1;
            //noteIndex -= 5;
            //if (noteIndex < 0)
            //    noteIndex += s_notesSharp.Length;

            noteIndex += interval;

            if (interval >= 0)
            {
                if (noteIndex >= s_notesSharp.Length)
                    noteIndex -= s_notesSharp.Length;
            }
            else
            {
                if (noteIndex < 0)
                    noteIndex += s_notesSharp.Length;
            }
        }

        private static void PrintDiatonicScales(DiatonicMode diatonicMode)
        {
            int intervalIndex = (int)diatonicMode;

            var rootNoteIndex = 0;
            for (int i = 0; i < intervalIndex; i++)
                Transpose(ref rootNoteIndex, s_majorScaleIntervals[i]);

            FieldInfo field = typeof(DiatonicMode).GetField(diatonicMode.ToString());
            var scaleName = field.GetCustomAttribute<DescriptionAttribute>().Description;
            var format = "Circle of {0} scales";
            Console.WriteLine(format, scaleName);
            Console.WriteLine(new string('-', format.Length - 3 + scaleName.Length));
            Console.WriteLine();

            for (var i = 0; i < 6; i++)
                Transpose(ref rootNoteIndex, PerfectFourth);

            for (var i = 6; i > 0; i--)
            {
                Console.Write("[{0}b] ", i);
                PrintScale(intervalIndex, rootNoteIndex, s_notesFlat);
                Transpose(ref rootNoteIndex, -PerfectFourth);
            }

            Console.Write("[ {0}] ", 0);
            PrintScale(intervalIndex, rootNoteIndex, s_notesSharp);

            Transpose(ref rootNoteIndex, PerfectFifth);
            for (var i = 1; i < 7; i++)
            {
                Console.Write("[{0}#] ", i);
                PrintScale(intervalIndex, rootNoteIndex, s_notesSharp);
                Transpose(ref rootNoteIndex, PerfectFifth);
            }
        }

        private static void PrintScale(int intervalIndex, int noteIndex, string[] notes)
        {
            int steps = s_majorScaleIntervals.Length;

            for (; ; )
            {
                Console.Write("{0,-2}", notes[noteIndex]);
                Console.Write(" ");

                if (steps == 0)
                    break;

                Transpose(ref noteIndex, s_majorScaleIntervals[intervalIndex]);

                intervalIndex++;
                if (intervalIndex >= s_majorScaleIntervals.Length)
                    intervalIndex = 0;

                steps--;
            }

            Console.WriteLine();
        }
    }
}
