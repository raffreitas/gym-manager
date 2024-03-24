using FluentValidation.AspNetCore;
using FluentValidation;
using GymManager.Application.Validators;

using Microsoft.Extensions.DependencyInjection;

namespace GymManager.Application;
public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddMediator()
            .AddValidations();

        return services;
    }

    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.
            AddMediatR(x => x.RegisterServicesFromAssembly(typeof(ApplicationModule).Assembly));

        return services;
    }

    public static IServiceCollection AddValidations(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<RegisterUserCommandValidator>();
        services.AddFluentValidationAutoValidation();

        return services;
    }
}
