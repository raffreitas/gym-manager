namespace GymManager.Core;
public static class Configuration
{
    public static DatabaseConfiguration Database { get; set; } = new();

    public class DatabaseConfiguration
    {
        public string ConnectinString { get; set; } = string.Empty;
    }
}
