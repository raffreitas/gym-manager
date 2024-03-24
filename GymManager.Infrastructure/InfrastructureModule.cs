using GymManager.Core;
using GymManager.Core.Repositories;
using GymManager.Core.Services;
using GymManager.Infrastructure.AuthServices;
using GymManager.Infrastructure.Persistence;
using GymManager.Infrastructure.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GymManager.Infrastructure;
public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services
            .AddPersistence()
            .AddRepositories()
            .AddServices();

        return services;
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<GymManagerDbContext>(x => x.UseSqlServer(Configuration.Database.ConnectinString));

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();

        return services;

    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }

}
