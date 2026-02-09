using SharpTerm.UI;

namespace SharpTerm.Text;

public class PlainTextElement(string text) : IFormattedTextElement
{
    public string Text { get; } = text;
    public void ApplyTo(IPrintTarget printTarget, bool wrap, int maxWidth) => printTarget.PrintWrapping(Text);
}
