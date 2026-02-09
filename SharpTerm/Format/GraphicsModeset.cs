namespace SharpTerm.Format;

public class TextStyleModeset
{
    public IntensityMode Intensity { get; init; }
    public ScriptMode Script { get; init; }
    public DecorationMode Decoration { get; init; }
    public BlinkMode Blink { get; init; }
    public NegativeMode Negative { get; init; }
    public ConcealMode Conceal { get; init; }
    public StrikeMode Strike { get; init; }

    public TextStyleModeset(IntensityMode? intensity, ScriptMode? script, DecorationMode? decoration,
        BlinkMode? blink, NegativeMode? negative, ConcealMode? conceal, StrikeMode? strike)
    {
        this.Intensity = intensity ?? new(TextStyle.Inherit);
        this.Script = script ?? new(TextStyle.Inherit);
        this.Decoration = decoration ?? new(TextStyle.Inherit);
        this.Blink = blink ?? new(TextStyle.Inherit);
        this.Negative = negative ?? new(TextStyle.Inherit);
        this.Conceal = conceal ?? new(TextStyle.Inherit);
        this.Strike = strike ?? new(TextStyle.Inherit);
    }

    public List<string> GetCodes()
    {
        return [
            Intensity.Code,
            Script.Code,
            Decoration.Code,
            Blink.Code,
            Negative.Code,
            Conceal.Code,
            Strike.Code,
        ];
    }

}