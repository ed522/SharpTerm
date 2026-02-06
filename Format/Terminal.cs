using System.Text;

namespace SharpTerm.Format;

public class Terminal(Stream output)
{
    private Stream Output { get; } = output;

    private void OutputCodes(string term, params string[] codes)
    {
        Output.Write(Encoding.UTF8.GetBytes($"{Escapes.CSI}{string.Join(";", codes)}{term}"));
    }

    public void Print(string text)
    {
        Output.Write(Encoding.UTF8.GetBytes(text));
    }

    public void ResetAttributes()
    {
        OutputCodes(Escapes.SGR_TERM, Escapes.SGR_RESET);
    }
    public void SetColour(Colour colour)
    {
        OutputCodes(Escapes.SGR_TERM, colour.ForegroundCode);
        OutputCodes(Escapes.SGR_TERM, colour.BackgroundCode);
    }

    public void SetTextStyleModeset(TextStyleModeset mode)
    {
        // output every code that has been set
        OutputCodes(Escapes.SGR_TERM, mode.GetCodes().Where(s => s != TextStyle.Inherit).ToArray());
    }
    public void SetTextStyle(TextStyle mode)
    {
        OutputCodes(Escapes.SGR_TERM, mode.Code);
    }

    // cursor movement
    /// <summary>
    /// Moves the cursor by the specified number of lines.
    /// A positive number moves down, and a negative number moves up. (1,1) is the top-left corner.
    /// </summary>
    /// <param name="lines">the number of lines to move the cursor by</param>
    public void CursorMoveY(int lines)
    {
        if (lines > 0) OutputCodes(Escapes.CSI_CURSOR_MOVE_UP, lines.ToString());
        else if (lines < 0) OutputCodes(Escapes.CSI_CURSOR_MOVE_DOWN, (-lines).ToString());
        // if lines == 0, do nothing
    }
    /// <summary>
    /// Moves the cursor by the specified number of columns.
    /// A positive number moves right, and a negative number moves left. (1,1) is the top-left corner.
    /// </summary>
    /// <param name="columns">the number of columns to move the cursor by</param>
    public void CursorMoveX(int columns)
    {
        if (columns > 0) OutputCodes(Escapes.CSI_CURSOR_MOVE_RIGHT, columns.ToString());
        else if (columns < 0) OutputCodes(Escapes.CSI_CURSOR_MOVE_LEFT, (-columns).ToString());
        // if columns == 0, do nothing
    }
    /// <summary>
    /// Moves the cursor to the specified one-based position. (1,1) is the top-left corner.
    /// </summary>
    /// <param name="row">the row to move to, starting from 1</param>
    /// <param name="column">the column to move to, starting from 1</param>
    public void CursorMoveAbsolute(int row, int column)
    {
        OutputCodes(Escapes.CSI_CURSOR_MOVE_ABSOLUTE, $"{row};{column}");
    }
    /// <summary>
    /// Moves the cursor to the top-left corner.
    /// </summary>
    public void CursorHome()
    {
        OutputCodes(Escapes.CSI_CURSOR_MOVE_ABSOLUTE, "1;1");
    }

}