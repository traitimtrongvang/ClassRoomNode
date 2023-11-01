using Application.Drivens.PrimaryDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PrimaryDbPostgreSql.Settings;

namespace PrimaryDbPostgreSql;

public static class ServiceCollectionExt
{
    public static IServiceCollection AddPrimaryDbPostgreSql(this IServiceCollection services, IConfiguration config)
    {
        var assemblyName = typeof(ServiceCollectionExt).Assembly.GetName().Name!;
        var primaryDbPostgreSqlSettings = config.GetSection($"{assemblyName}:{nameof(PrimaryDbPostgreSqlSettings)}").Get<PrimaryDbPostgreSqlSettings>()!;
        
        services.Configure<PrimaryDbPostgreSqlSettings>(config.GetSection($"{assemblyName}:{nameof(PrimaryDbPostgreSqlSettings)}"));
        
        services.AddDbContext<PrimaryDbPostgreSqlContext>(
            optionsAction => optionsAction.UseNpgsql(primaryDbPostgreSqlSettings.ConnectionStr));
        
        services.AddScoped<PrimaryDbContext>(provider => provider.GetRequiredService<PrimaryDbPostgreSqlContext>());
        
        return services;
    }
}