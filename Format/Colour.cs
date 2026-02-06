namespace SharpTerm.Format;

public abstract class Colour
{
    // base class for colours
    public abstract string ForegroundCode { get; protected init; }
    public abstract string BackgroundCode { get; protected init; }

}
