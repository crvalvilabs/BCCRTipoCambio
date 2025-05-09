using BCCR.TipoCambio.Domain.Repositorios;
using BCCR.TipoCambio.Infraestructura.Database;
using BCCR.TipoCambio.Infraestructura.Mappers;
using BCCR.TipoCambio.Infraestructura.Repositorios;
using BCCR.TipoCambio.Infraestructura.Loggin;
using BCCR.TipoCambio.Aplicacion.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BCCR.TipoCambio.Infraestructura;

/// <summary>
/// Provides methods for configuring dependency injection for the infrastructure layer.
/// This class is responsible for registering services, repositories, and other infrastructure
/// dependencies within the application's service container.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Configures and registers the infrastructure layer dependencies in the service collection.
    /// This method sets up database contexts, repositories, and other infrastructure-related services needed
    /// by the application.
    /// </summary>
    /// <param name="services">The service collection to which the dependencies are being added.</param>
    /// <param name="configuration">The application configuration containing connection strings or other relevant settings.</param>
    /// <returns>The updated service collection with the infrastructure dependencies registered.</returns>
    public static IServiceCollection AddInfraestructura(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<NubaHotelContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("NubaHotel"));
        });
        
        services.AddSingleton<IRegistroLog, RegistroLog>();
        services.AddScoped<IExchageRateRepositorio, ExchangeRateRepositorio>();
        services.AddSingleton<ExchangeRateMapper>();
        return services;
    }
}
