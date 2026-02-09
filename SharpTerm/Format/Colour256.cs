namespace SharpTerm.Format;

public class Colour256(byte index) : Colour
{
    public override string ForegroundCode { get; protected init; } = Escapes.SGR_FG_HICOLOR_256 + $";{index}";
    public override string BackgroundCode { get; protected init; } = Escapes.SGR_BG_HICOLOR_256 + $";{index}";
}
