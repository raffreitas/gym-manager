namespace GymManager.Core;
public static class Configuration
{
    public static DatabaseConfiguration Database { get; set; } = new();
    public static SecretsConfiguration Secrets { get; set; } = new();

    public class DatabaseConfiguration
    {
        public string ConnectinString { get; set; } = string.Empty;
    }

    public class SecretsConfiguration
    {
        public string JwtSecretKey { get; set; } = string.Empty;
        public string JwtAudience { get; set; } = string.Empty;
        public string JwtIssuer { get; set; } = string.Empty;
    }
}
