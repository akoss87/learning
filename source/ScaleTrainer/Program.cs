using System;
using System.ComponentModel;
using System.Reflection;

namespace ScaleTrainer
{
    enum DiatonicMode
    {
        [Description("Ionian (Major)")]
        Ionian,
        [Description("Dorian")]
        Dorian,
        [Description("Phrygian")]
        Phrygian,
        [Description("Lydian")]
        Lydian,
        [Description("Mixolydian")]
        Mixolydian,
        [Description("Aeolian (Minor)")]
        Aeolian,
        [Description("Locrian")]
        Locrian,
    }

    enum Distance
    {
        PerfectUnison,
        MinorSecond,
        MajorSecond,
        MinorThird,
        MajorThird,
        PerfectFourth,
        Tritone,
        PerfectFifth,
        MinorSixth,
        MajorSixth,
        MinorSeventh,
        MajorSeventh,
        PerfectOctave,
    }

    class Program
    {
        static readonly Distance[] s_majorScaleDistances = new Distance[7]
        {
            Distance.MajorSecond,
            Distance.MajorSecond,
            Distance.MinorSecond,
            Distance.MajorSecond,
            Distance.MajorSecond,
            Distance.MajorSecond,
            Distance.MinorSecond,
        };

        static readonly string[] s_notesSharp = new string[12] { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
        static readonly string[] s_notesFlat = new string[12] { "C", "Db", "D", "Eb", "E", "F", "Gb", "G", "Ab", "A", "Bb", "B" };

        static void Main(string[] args)
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

            if (args.Length > 0)
                switch (args[0].ToLowerInvariant())
                {
                    case "--print-majors":
                        PrintDiatonicScales(DiatonicMode.Ionian);
                        break;
                    case "--print-minors":
                        PrintDiatonicScales(DiatonicMode.Aeolian);
                        break;
                }
        }

        static void Transpose(ref int noteIndex, Distance distance, bool up)
        {
            if (up)
            {
                noteIndex += (int)distance;
                if (noteIndex >= s_notesSharp.Length)
                    noteIndex -= s_notesSharp.Length;
            }
            else
            {
                noteIndex -= (int)distance;
                if (noteIndex < 0)
                    noteIndex += s_notesSharp.Length;
            }
        }

        private static void PrintDiatonicScales(DiatonicMode diatonicMode)
        {
            int distanceIndex = (int)diatonicMode;

            var rootNoteIndex = 0;
            for (int i = 0; i < distanceIndex; i++)
                Transpose(ref rootNoteIndex, s_majorScaleDistances[i], up: true);

            FieldInfo field = typeof(DiatonicMode).GetField(diatonicMode.ToString());
            var scaleName = field.GetCustomAttribute<DescriptionAttribute>().Description;
            var format = "Circle of {0} scales";
            Console.WriteLine(format, scaleName);
            Console.WriteLine(new string('-', format.Length - 3 + scaleName.Length));
            Console.WriteLine();

            for (var i = 0; i < 6; i++)
                Transpose(ref rootNoteIndex, Distance.PerfectFourth, up: true);

            for (var i = 6; i > 0; i--)
            {
                Console.Write("[{0}b] ", i);
                PrintScale(distanceIndex, rootNoteIndex, s_notesFlat);
                Transpose(ref rootNoteIndex, Distance.PerfectFourth, up: false);
            }

            Console.Write("[ {0}] ", 0);
            PrintScale(distanceIndex, rootNoteIndex, s_notesSharp);

            Transpose(ref rootNoteIndex, Distance.PerfectFifth, up: true);
            for (var i = 1; i < 7; i++)
            {
                Console.Write("[{0}#] ", i);
                PrintScale(distanceIndex, rootNoteIndex, s_notesSharp);
                Transpose(ref rootNoteIndex, Distance.PerfectFifth, up: true);
            }
        }

        private static void PrintScale(int distanceIndex, int noteIndex, string[] notes)
        {
            int steps = s_majorScaleDistances.Length;

            for (; ; )
            {
                Console.Write("{0,-2}", notes[noteIndex]);
                Console.Write(" ");

                if (steps == 0)
                    break;

                Transpose(ref noteIndex, s_majorScaleDistances[distanceIndex], up: true);

                distanceIndex++;
                if (distanceIndex >= s_majorScaleDistances.Length)
                    distanceIndex = 0;

                steps--;
            }

            Console.WriteLine();
        }
    }
}
