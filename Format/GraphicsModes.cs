namespace SharpTerm.Format;

public class TextStyle(string code)
{
    public static string Inherit = "";
    public string Code { get; } = code;
}
public class IntensityMode(string code): TextStyle(code)
{
    public static readonly IntensityMode Bold = new(Escapes.SGR_BOLD);
    public static readonly IntensityMode Faint = new(Escapes.SGR_FAINT);
    public static readonly IntensityMode Normal = new(Escapes.SGR_NO_BOLD_FAINT);
}
public class ScriptMode(string code): TextStyle(code)
{
    public static readonly ScriptMode Italic = new(Escapes.SGR_ITALIC);
    public static readonly ScriptMode Fraktur = new(Escapes.SGR_FRAKTUR);
    public static readonly ScriptMode Normal = new(Escapes.SGR_NO_ITALIC_FRAKTUR);
}
public class DecorationMode(string code): TextStyle(code)
{
    public static readonly DecorationMode Underline = new(Escapes.SGR_UNDERLINE);
    public static readonly DecorationMode DoubleUnderline = new(Escapes.SGR_DOUBLE_UNDERLINE);
    public static readonly DecorationMode NoUnderline = new(Escapes.SGR_NO_UNDERLINE);
}
public class BlinkMode(string code): TextStyle(code)
{
    public static readonly BlinkMode Slow = new(Escapes.SGR_BLINK_SLOW);
    public static readonly BlinkMode Fast = new(Escapes.SGR_BLINK_FAST);
    public static readonly BlinkMode NoBlink = new(Escapes.SGR_NO_BLINK);
}
public class NegativeMode(string code): TextStyle(code)
{
    public static readonly NegativeMode Negative = new(Escapes.SGR_NEGATIVE);
    public static readonly NegativeMode NoNegative = new(Escapes.SGR_NO_NEGATIVE);
}
public class ConcealMode(string code): TextStyle(code)
{
    public static readonly ConcealMode Conceal = new(Escapes.SGR_CONCEAL);
    public static readonly ConcealMode NoConceal = new(Escapes.SGR_NO_CONCEAL);
}
public class StrikeMode(string code): TextStyle(code)
{
    public static readonly StrikeMode Strike = new(Escapes.SGR_STRIKE);
    public static readonly StrikeMode NoStrike = new(Escapes.SGR_NO_STRIKE);
}
public class DoubleHeightMode(string code): TextStyle(code)
{
    public static readonly DoubleHeightMode TopHalf = new(Escapes.VT_DOUBLE_HEIGHT_TOP);
    public static readonly DoubleHeightMode BottomHalf = new(Escapes.VT_DOUBLE_HEIGHT_BOTTOM);
    public static readonly DoubleHeightMode Normal = new(Escapes.VT_SINGLE_HEIGHT);
}