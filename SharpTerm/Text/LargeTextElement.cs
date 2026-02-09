using SharpTerm.Format;
using SharpTerm.UI;
using System.Diagnostics.CodeAnalysis;

namespace SharpTerm.Text;

[SuppressMessage("Style", "IDE0305:Simplify collection initialization", Justification = "Reduces readability")]
[SuppressMessage("Style", "IDE0057:Use range operator", Justification = "Reduces readability")]
public class LargeTextElement(string text) : IFormattedTextElement
{
    public string Text { get; } = text;
    
    public void ApplyTo(IPrintTarget printTarget, bool wrap, int maxWidth)
    {
        // split text into lines, and print each line with double height mode
        var lines = Wrap(Text.Split('\n'), maxWidth, printTarget.GetTabSize());
        foreach (var line in lines)
        {
            printTarget.PrintCode(Escapes.VT_DOUBLE_HEIGHT_TOP);
            printTarget.PrintRaw(line);
            printTarget.PrintCode(Escapes.VT_DOUBLE_HEIGHT_BOTTOM);
            printTarget.PrintRaw(line);
            printTarget.PrintRaw("\n");
        }

    }
    private static string[] Wrap(string[] lines, int maxWidth, int tabSize)
    {
        var wrappedLines = new List<string>();
        // wrap each line to maxWidth, and add to wrappedLines
        var charsPerLine = Math.Max(1, maxWidth / 2);
        
        foreach (var line in lines)
        {
            for (int i = 0; i < line.Length; /* manually increment */)
            {
                string expanded = line.Replace("\t", new string(' ', tabSize));
                // get substring (index, length) - up to charsPerLine, but not past the end of the line
                // if there is leading whitespace, shift the window over
                string hardWrap;
                hardWrap = expanded.Substring(i, Math.Min(charsPerLine, expanded.Length - i));
                while (hardWrap.StartsWith(' ') && i < line.Length){
                    i++;
                    hardWrap = expanded.Substring(i, Math.Min(charsPerLine, expanded.Length - i));
                }
                // find last breaking char (intentionally excludes tabs)
                int wrapIndex = hardWrap.LastIndexOfAny([' ', '-', '_', '.', ',', ';', ':']);

                if (wrapIndex == -1)
                {
                    // can't wrap
                    wrappedLines.Add(hardWrap);
                    i += hardWrap.Length;
                }
                else
                {
                    // include the breaking character in the previous line to avoid formatting errors
                    //  like this
                    wrappedLines.Add(hardWrap.Substring(0, wrapIndex + 1));
                    i += wrapIndex + 1;
                }
            }
        }

        return wrappedLines.ToArray();
    }
}
