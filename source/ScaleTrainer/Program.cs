using System;

namespace ScaleTrainer
{
    class Program
    {
        static readonly int[] s_majorScaleDistances = new int[7] { 2, 2, 1, 2, 2, 2, 1 };
        static readonly string[] s_notesSharp = new string[12] { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
        static readonly string[] s_notesFlat = new string[12] { "C", "Db", "D", "Eb", "E", "F", "Gb", "G", "Ab", "A", "Bb", "B" };

        static void Main(string[] args)
        {
            Console.WriteLine("Major scales");
            Console.WriteLine("------------");
            Console.WriteLine();

            int rootNoteIndex = 6; // Gb
            for (var i = 6; i > 0; i--)
            {
                Console.Write("[{0}b] ", i);
                PrintScale(rootNoteIndex, s_notesFlat);
                rootNoteIndex -= 5;
                if (rootNoteIndex < 0)
                    rootNoteIndex += s_notesFlat.Length;
            }


            Console.Write("[ {0}] ", 0);
            PrintScale(0, s_notesSharp);

            rootNoteIndex = 7; // G
            for (var i = 1; i < 7; i++)
            {
                Console.Write("[{0}#] ", i);
                PrintScale(rootNoteIndex, s_notesSharp);
                rootNoteIndex += 7;
                if (rootNoteIndex >= s_notesSharp.Length)
                    rootNoteIndex -= s_notesSharp.Length;
            }
        }

        private static void PrintScale(int noteIndex, string[] notes)
        {
            int distanceIndex = 0;
            for (; ; )
            {
                Console.Write("{0,-2}", notes[noteIndex]);
                Console.Write(" ");

                if (distanceIndex >= s_majorScaleDistances.Length)
                    break;

                noteIndex += s_majorScaleDistances[distanceIndex];
                if (noteIndex >= notes.Length)
                    noteIndex -= notes.Length;

                distanceIndex++;
            }

            Console.WriteLine();
        }
    }
}
