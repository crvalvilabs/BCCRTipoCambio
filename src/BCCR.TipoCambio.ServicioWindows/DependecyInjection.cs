namespace BCCR.TipoCambio.ServicioWindows;

/// <summary>
/// Provides extension methods for dependency injection related to the ServicioWindows functionality.
/// </summary>
public static class DependecyInjection
{
    /// <summary>
    /// Adds the ServicioWindows-related dependencies to the specified service collection.
    /// </summary>
    /// <param name="services">The service collection where the dependencies will be registered.</param>
    /// <param name="configuration">The configuration object used to configure the registered services.</param>
    /// <returns>The updated service collection with the ServicioWindows-related dependencies.</returns>
    public static IServiceCollection AddServicioWindows(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}