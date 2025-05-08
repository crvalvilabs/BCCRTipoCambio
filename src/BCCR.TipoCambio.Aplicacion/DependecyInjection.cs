using BCCR.TipoCambio.Application.CasosDeUso;
using BCCR.TipoCambio.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BCCR.TipoCambio.Application;

/// <summary>
/// Provides an extension method for configuring and registering application-level dependencies
/// within the dependency injection container.
/// </summary>
public static class DependecyInjection
{
    /// <summary>
    /// Adds application-level dependencies to the specified service collection.
    /// </summary>
    /// <param name="services">The service collection to which application-level dependencies will be registered.</param>
    /// <param name="configuration">The application configuration object.</param>
    /// <returns>The updated service collection with the registered application-level dependencies.</returns>
    public static IServiceCollection AddAplicacion(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IObtenerTipoCambioUseCase, ObtenerTipocambioUseCase>();
        
        return services;
    }
    
}