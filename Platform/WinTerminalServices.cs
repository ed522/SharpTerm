namespace SharpTerm.Platform;

using System;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

[SupportedOSPlatform("windows")]
public partial class WinTerminalServices
{
    public const int STDIN = -10;
    public const int STDOUT = -11;

    [LibraryImport("kernel32.dll", SetLastError = true)]
    private static partial IntPtr GetStdHandle(int nStdHandle);

    [LibraryImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static partial bool GetConsoleMode(IntPtr handle, out uint mode);

    [LibraryImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static partial bool SetConsoleMode(IntPtr handle, uint mode);

    private readonly uint defaultOutMode;
    private readonly uint defaultInMode;
    private readonly IntPtr outHandle;
    private readonly IntPtr inHandle;
    /// <summary>
    /// Get handles, and store default modes for reset
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    internal WinTerminalServices()
    {
        // apparently they don't need to be freed
        outHandle = GetStdHandle(STDOUT);
        inHandle = GetStdHandle(STDIN);
        
        if (outHandle == IntPtr.Zero)
        {
            throw new InvalidOperationException("Failed to get stdout handle");
        }
        if (inHandle == IntPtr.Zero)
        {
            throw new InvalidOperationException("Failed to get stdin handle");
        }

        if (!GetConsoleMode(outHandle, out defaultOutMode))
        {
            throw new InvalidOperationException("Failed to get stdout console mode");
        }
        if (!GetConsoleMode(inHandle, out defaultInMode))
        {
            throw new InvalidOperationException("Failed to get stdin console mode");
        }
    }

    // in
    private const uint ENABLE_WINDOW_INPUT = 0x0008; // get window resize events
    private const uint ENABLE_VIRTUAL_TERMINAL_INPUT = 0x0200; // allow VT sequences, arrow keys etc

    // out    
    private const uint ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004; // allow VT output sequences, i.e. colours
    private const uint DISABLE_NEWLINE_AUTO_RETURN = 0x0008; // some auto-formatting to disable

    internal void WinMakeRaw()
    {
        SetConsoleMode(inHandle, ENABLE_VIRTUAL_TERMINAL_INPUT | ENABLE_WINDOW_INPUT);
        SetConsoleMode(outHandle, ENABLE_VIRTUAL_TERMINAL_PROCESSING | DISABLE_NEWLINE_AUTO_RETURN);
    }
    internal void WinMakeCooked()
    {
        SetConsoleMode(inHandle, defaultInMode);
        SetConsoleMode(outHandle, defaultOutMode);
    }

}