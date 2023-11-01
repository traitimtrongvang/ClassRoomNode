using Application.Drivings.Pipelines;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceCollectionExt
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        #region MediatR

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExt).Assembly));
        
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationPipeline<,>));
        
        // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipeline<,>));

        #endregion
        
        return services;
    }
}