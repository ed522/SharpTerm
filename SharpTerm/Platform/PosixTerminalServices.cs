using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace SharpTerm.Platform;

[SupportedOSPlatform("linux")]
[SupportedOSPlatform("freebsd")]
[SupportedOSPlatform("macos")]
public sealed partial class PosixTerminalServices: IDisposable
{

    private const int STDIN = 0;

    [LibraryImport("tcwrapper_posix", SetLastError = true)]
    private static partial IntPtr tcget(int fd);
    [LibraryImport("libc", SetLastError = true)]
    private static partial int tcsetattr(int fd, int optional_actions, IntPtr termios);
    [LibraryImport("libc", SetLastError = true)]
    private static partial void cfmakeraw(IntPtr termios);

    // for cleanup
    [LibraryImport("libc", SetLastError = true)]
    private static partial void free(IntPtr ptr);

    private IntPtr originalTermios;
    private IntPtr rawTermios;
    private bool _disposed = false;

    internal PosixTerminalServices()
    {
        originalTermios = tcget(STDIN);
        rawTermios = tcget(STDIN);
        if (originalTermios == IntPtr.Zero || rawTermios == IntPtr.Zero)
        {
            throw new InvalidOperationException("Failed to get terminal attributes");
        }
        cfmakeraw(rawTermios);
    }

    internal void PosixMakeRaw()
    {
        Console.WriteLine("PosixMakeRaw");
        if (tcsetattr(STDIN, 0, rawTermios) != 0)
        {
            throw new InvalidOperationException("Failed to set terminal to raw mode");
        }
    }
    internal void PosixMakeCooked()
    {
        Console.WriteLine("PosixMakeCooked");
        if (tcsetattr(STDIN, 0, originalTermios) != 0)
        {
            throw new InvalidOperationException("Failed to restore terminal attributes");
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    ~PosixTerminalServices()
    {
        Dispose(false);
    }
    // normally protected virtual, first parameter "managed"/"disposing"
    void Dispose(bool _)
    {
        if (_disposed)
            return;

        // no managed assets
        free(originalTermios);
        originalTermios = IntPtr.Zero;
        free(rawTermios);
        rawTermios = IntPtr.Zero;
        _disposed = true;
    }

}