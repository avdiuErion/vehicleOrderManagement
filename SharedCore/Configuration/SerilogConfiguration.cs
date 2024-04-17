using Serilog;
using Serilog.Events;

namespace SharedCore.Configuration;

public static class SerilogConfiguration
{
    public static void ConfigureSerilog()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();
    }
}