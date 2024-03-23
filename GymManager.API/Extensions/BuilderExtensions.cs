using GymManager.Core;
using GymManager.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;

namespace GymManager.API.Extensions;

public static class BuilderExtensions
{
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        Configuration.Database.ConnectinString = builder.Configuration
                                                    .GetConnectionString("DefaultConnection") ?? string.Empty;
    }
    public static void AddDatabase(this IServiceCollection services)
    {
        services.AddDbContext<GymManagerDbContext>(x => x.UseSqlServer(Configuration.Database.ConnectinString));
    }
}
