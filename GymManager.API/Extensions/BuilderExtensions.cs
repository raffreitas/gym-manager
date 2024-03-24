using GymManager.Core;

using Microsoft.EntityFrameworkCore;

namespace GymManager.API.Extensions;

public static class BuilderExtensions
{
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        Configuration.Database.ConnectinString = builder.Configuration
                                                    .GetConnectionString("DefaultConnection") ?? string.Empty;

        var secrets = new Configuration.SecretsConfiguration();
        builder.Configuration.GetSection("Secrets").Bind(secrets);
        Configuration.Secrets = secrets;
    }
}
