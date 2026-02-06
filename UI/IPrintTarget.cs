namespace SharpTerm.UI;

public interface IPrintTarget
{
    public void PrintWrapping(string text);
    public void PrintRaw(string text);
    public void PrintCode(string code);
    public void PrintCode(string code, params string[] arguments);
}