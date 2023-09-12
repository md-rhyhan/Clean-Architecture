using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestFluentValidation.Infrastructure.AppContext;

namespace TestFluentValidation.Infrastructure;

public static class RegisterService
{
    public static IServiceCollection InfrastructureConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TestFluentValidationDbContext>(option =>
        {
            option.UseSqlServer(configuration.GetConnectionString("DbConn"));
        });

        return services;
    }

}
