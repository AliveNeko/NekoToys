

namespace NekoToys.DevToys.Core;

internal static class Logger
{
    internal static void Log(string featureName, string message)
    {
        Serilog.Log.Information("{}, {}", featureName, message);
    }

    internal static void LogFault(string featureName, Exception ex, string? message = null)
    {
        Serilog.Log.Error("{}, {}, {}", featureName, ex.Message, message ?? "");
    }

    private static async Task LogFaultAsync(string featureName, Exception? ex, string? message)
    {
        await Task.Run(() =>
        {
            Serilog.Log.Error("{}, {}, {}", featureName, ex?.Message, message ?? "");
        });
    }
}