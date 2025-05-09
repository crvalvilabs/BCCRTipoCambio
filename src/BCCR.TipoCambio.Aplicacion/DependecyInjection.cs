using BCCR.TipoCambio.Aplicacion.CasosDeUso;
using BCCR.TipoCambio.Aplicacion.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BCCR.TipoCambio.Aplicacion;

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
    /// <returns>The updated service collection with the registered application-level dependencies.</returns>
    public static IServiceCollection AddAplicacion(this IServiceCollection services)
    {
        services.AddScoped<IActualizarTasaUseCase, ActualizarTasaUseCase>();
        services.AddScoped<IObtenerTipoCambioUseCase, ObtenerTipocambioUseCase>();
        
        return services;
    }
    
}