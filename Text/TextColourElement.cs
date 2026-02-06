using SharpTerm.Format;
using SharpTerm.UI;

namespace SharpTerm.Text;

public class TextColourElement(Colour colour) : IFormattedTextElement
{
    public Colour ColourCode { get; } = colour;
    public void ApplyTo(IPrintTarget printTarget, bool wrap, int maxWidth) => 
        printTarget.PrintCode(ColourCode.ForegroundCode, ColourCode.BackgroundCode);
}