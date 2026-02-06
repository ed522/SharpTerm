using SharpTerm.UI;

namespace SharpTerm.Text;

public interface IFormattedTextElement
{
    public void ApplyTo(IPrintTarget printTarget, bool wrap, int maxWidth);
}
