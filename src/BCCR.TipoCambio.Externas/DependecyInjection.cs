using BCCR.TipoCambio.Domain.Servicios;
using BCCR.TipoCambio.Externas.BCCR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BCCR.TipoCambio.Externas;

/// <summary>
/// Provides an extension method to configure and register external dependencies
/// for the exchange rate service using dependency injection.
/// </summary>
public static class DependecyInjection
{
    /// <summary>
    /// Registers external service dependencies for the exchange rate application.
    /// </summary>
    /// <param name="services">The service collection to which the external dependencies will be added.</param>
    /// <returns>The updated service collection with the added external dependencies.</returns>
    public static IServiceCollection AddExternas(this IServiceCollection services)
    {
        services.AddHttpClient<IConsultaTipoCambio, ConsultaTipoCambio>();
        return services;
    }
}