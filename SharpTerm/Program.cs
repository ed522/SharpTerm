using System.Runtime.Versioning;
using SharpTerm.Platform;

internal class Program
{
    [SupportedOSPlatform("windows")]
    [SupportedOSPlatform("linux")]
    [SupportedOSPlatform("freebsd")]
    [SupportedOSPlatform("macos")]
    private static void Main(string[] args)
    {
        Console.WriteLine("program start");
        TerminalServices services = new();
        services.MakeRaw();
        Console.WriteLine("raw mode, press ';' to exit");
        while (true)
        {
            var key = Console.ReadKey(true);
            if (key.KeyChar == ';')
            {
                break;
            }
            else {
                Console.Write(key.KeyChar);
            }
        }
        services.MakeCooked();
        Console.WriteLine("program end");
    }
}