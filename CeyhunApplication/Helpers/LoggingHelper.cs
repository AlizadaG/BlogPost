using Sentry.Extensibility;

namespace CeyhunApplication.Helpers
{
    public class SentryEventProcessor : ISentryEventProcessor
    {
        public SentryEvent Process(SentryEvent @event)
        {
            LoggingHelper.LogToFile(@event);
            return @event;
        }
    }
    public static class LoggingHelper
    {
        public static void LogToFile(SentryEvent @event)
        {
            var logPath = Path.Combine(Directory.GetCurrentDirectory(), "sentry_logs.txt");

            try
            {
                using (var writer = new StreamWriter(logPath, true))
                {
                    writer.WriteLine($"{DateTime.Now}: {@event.Message?.Formatted ?? @event.Exception?.Message}");
                    writer.WriteLine(@event.ToString());
                    writer.WriteLine("------------------------------------------------");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
