namespace SharpTerm.Format;

public class ColourTrue(byte r, byte g, byte b) : Colour
{
    public override string ForegroundCode { get; protected init; } = Escapes.SGR_FG_HICOLOR_TRUE + $";{r};{g};{b}";
    public override string BackgroundCode { get; protected init; } = Escapes.SGR_BG_HICOLOR_TRUE + $";{r};{g};{b}";
}
