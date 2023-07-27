namespace CodeCool.SeasonalProductDiscounter.Service.Logger;

public class ConsoleLogger : ILogger
{
    private void LogMessage(string message, string type)
    {
        var entry = CreateLogEntry(message, type);
        Console.WriteLine(entry);
    }
    
    private static string CreateLogEntry(string message, string type) => $"[{DateTime.Now}] {type}: {message}";

    public void LogInfo(string message)
    {
        LogMessage(message, "INFO");
    }

    public void LogError(string message)
    {
        LogMessage(message, "ERROR");
    }
}
