using System.Runtime.Versioning;

namespace SharpTerm.Platform;

public class TerminalServices: IDisposable
{

    private readonly WinTerminalServices? winServices;
    private readonly PosixTerminalServices? posixServices;
    private bool _disposed = false;

    public TerminalServices()
    {
        if (OperatingSystem.IsWindows())
        {
            winServices = new WinTerminalServices();
        } else if (OperatingSystem.IsLinux() || OperatingSystem.IsMacOS() || OperatingSystem.IsFreeBSD())
        {
            posixServices = new PosixTerminalServices();
        }
        else
        {
            throw new PlatformNotSupportedException("Unknown platform");
        }
    }

    public void MakeRaw()
    {
        Console.WriteLine("MakeRaw");
        if (OperatingSystem.IsWindows())
        {
            // services must be initialised here
            winServices!.WinMakeRaw();
        } else if (OperatingSystem.IsLinux() || OperatingSystem.IsMacOS() || OperatingSystem.IsFreeBSD())
        {
            Console.WriteLine("Posix");
            posixServices!.PosixMakeRaw();
        }
        else
        {
            throw new PlatformNotSupportedException("Unknown platform");
        }
    }

    public void MakeCooked()
    {
        if (OperatingSystem.IsWindows())
        {
            // services must be initialised here
            winServices!.WinMakeCooked();
        } else if (OperatingSystem.IsLinux() || OperatingSystem.IsMacOS() || OperatingSystem.IsFreeBSD())
        {
            posixServices!.PosixMakeCooked();
        }
        else
        {
            throw new PlatformNotSupportedException("Unknown platform");
        }
    }

    public void Dispose()
    {
        Dispose(true);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        if (disposing && (OperatingSystem.IsLinux() || OperatingSystem.IsMacOS() || OperatingSystem.IsFreeBSD()))
        {
            posixServices?.Dispose();
        }
        else {
            // pass, posix services will also be freed
        }
        _disposed = true;
    }

}