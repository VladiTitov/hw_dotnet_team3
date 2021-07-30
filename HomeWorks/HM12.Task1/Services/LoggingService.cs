using Serilog;

namespace HM12.Task1.Services
{
    public static class LoggingService
    {
        static LoggingService()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("logs/motocyclesBD_.log", rollingInterval: RollingInterval.Hour)
                .CreateLogger();
        }

        public static void AddEventToLog(string message) => Log.Information(message);
    }
}
