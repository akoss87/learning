using System.ComponentModel;

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
}
