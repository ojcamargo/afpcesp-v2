using afpcesp.application.services;
using Microsoft.Extensions.DependencyInjection;

namespace afpcesp.application;

public static class Startup
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService,UserService>();
        return services;
    }
}