using SharpTerm.Format;
using SharpTerm.UI;
using System.Diagnostics.CodeAnalysis;

namespace SharpTerm.Text;

[SuppressMessage("Style", "IDE0305:Simplify collection initialization", Justification = "Reduces readability")]
public class TextStyleElement(TextStyleModeset modeset) : IFormattedTextElement
{
    public TextStyleModeset Modeset { get; } = modeset;
    public void ApplyTo(IPrintTarget printTarget, bool wrap, int maxWidth) => 
        printTarget.PrintCode(Escapes.SGR_TERM, Modeset.GetCodes().Where(s => s != TextStyle.Inherit).ToArray());
}
