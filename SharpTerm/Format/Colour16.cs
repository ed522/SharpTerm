namespace SharpTerm.Format;

/// <summary>
/// Describes a four-bit (RGBI) terminal colour, with three channels, eight colours and a brightness flag.
/// </summary>
public class Colour16: Colour
{
    public static readonly Colour16 Black = new(Escapes.SGR_FG_BLACK, Escapes.SGR_BG_BLACK);
    public static readonly Colour16 Red = new(Escapes.SGR_FG_RED, Escapes.SGR_BG_RED);
    public static readonly Colour16 Green = new(Escapes.SGR_FG_GREEN, Escapes.SGR_BG_GREEN);
    public static readonly Colour16 Blue = new(Escapes.SGR_FG_BLUE, Escapes.SGR_BG_BLUE);
    public static readonly Colour16 Yellow = new(Escapes.SGR_FG_YELLOW, Escapes.SGR_BG_YELLOW);
    public static readonly Colour16 Cyan = new(Escapes.SGR_FG_CYAN, Escapes.SGR_BG_CYAN);
    public static readonly Colour16 Magenta = new(Escapes.SGR_FG_MAGENTA, Escapes.SGR_BG_MAGENTA);
    public static readonly Colour16 White = new(Escapes.SGR_FG_WHITE, Escapes.SGR_BG_WHITE);
    public static readonly Colour16 BrightBlack = new(Escapes.SGR_FG_BRIGHT_BLACK, Escapes.SGR_BG_BRIGHT_BLACK);
    public static readonly Colour16 BrightRed = new(Escapes.SGR_FG_BRIGHT_RED, Escapes.SGR_BG_BRIGHT_RED);
    public static readonly Colour16 BrightGreen = new(Escapes.SGR_FG_BRIGHT_GREEN, Escapes.SGR_BG_BRIGHT_GREEN);
    public static readonly Colour16 BrightBlue = new(Escapes.SGR_FG_BRIGHT_BLUE, Escapes.SGR_BG_BRIGHT_BLUE);
    public static readonly Colour16 BrightYellow = new(Escapes.SGR_FG_BRIGHT_YELLOW, Escapes.SGR_BG_BRIGHT_YELLOW);
    public static readonly Colour16 BrightCyan = new(Escapes.SGR_FG_BRIGHT_CYAN, Escapes.SGR_BG_BRIGHT_CYAN);
    public static readonly Colour16 BrightMagenta = new(Escapes.SGR_FG_BRIGHT_MAGENTA, Escapes.SGR_BG_BRIGHT_MAGENTA);
    public static readonly Colour16 BrightWhite = new(Escapes.SGR_FG_BRIGHT_WHITE, Escapes.SGR_BG_BRIGHT_WHITE);
    public static readonly Colour16 Default = new(Escapes.SGR_FG_DEFAULT, Escapes.SGR_BG_DEFAULT);

    public override string ForegroundCode { get; protected init; }
    public override string BackgroundCode { get; protected init; }
    private Colour16(string foregroundCode, string backgroundCode)
    {
        this.ForegroundCode = foregroundCode;
        this.BackgroundCode = backgroundCode;
    }
    public Colour16(Colour16 foreground, Colour16 background)
    {
        this.ForegroundCode = foreground.ForegroundCode;
        this.BackgroundCode = background.BackgroundCode;
    }
}