using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TestFluentValidation.Application.Profiles;
using TestFluentValidation.Application.Repositories.Base;
using TestFluentValidation.Application.Repositories.EntityRepository;

namespace TestFluentValidation.Application;

public static class RegisterService
{
    public static IServiceCollection ApplicationConfiguration(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        services.AddAutoMapper(typeof(MappingProfile).Assembly);

        services.AddScoped(typeof(IBaseRepository<,,>), typeof(BaseRepository<,,>));

        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IStateRepository, StateRepository>();
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();

        return services;
    }
}

