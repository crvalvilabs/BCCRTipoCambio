using BCCR.TipoCambio.Aplicacion.Interfaces;

namespace BCCR.TipoCambio.ServicioWindows;

/// <summary>
/// Represents a background service that periodically fetches exchange rate information
/// by invoking the corresponding use case.
/// </summary>
public class Worker : BackgroundService
{
    /// <summary>
    /// A readonly field that holds an instance of <c>IServiceScopeFactory</c>, used for creating service scopes.
    /// </summary>
    /// <remarks>
    /// The <c>IServiceScopeFactory</c> is used to generate a new scoped service container,
    /// allowing the <c>Worker</c> class to resolve scoped dependencies, such as <c>IObtenerTipoCambioUseCase</c>.
    /// The created scope ensures proper management of dependencies with a lifetime bound to the scope's duration.
    /// </remarks>
    private readonly IServiceScopeFactory _scopeFactory;

    /// <summary>
    /// A readonly field that holds an instance of <c>IRegistroLog</c>, used for logging exceptions or other significant events.
    /// </summary>
    /// <remarks>
    /// The <c>IRegistroLog</c> interface provides a method to log information, enabling the <c>Worker</c> class
    /// to capture and persist exception details or other logs during the execution of its background operations.
    /// </remarks>
    private readonly IRegistroLog _logger;

    /// <summary>
    /// Represents a background worker service that periodically performs an operation
    /// to fetch exchange rate information by using the defined use case.
    /// </summary>
    /// <param name="scopeFactory">The service scope factory used to create a service scope.</param>
    /// <param name="logger">The logger used to log exceptions.</param>
    /// <remarks>
    /// This constructor initializes the service scope factory used to create a service scope.
    /// </remarks>
    public Worker(IServiceScopeFactory scopeFactory, IRegistroLog logger)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
    }

    /// <summary>
    /// Executes the background task to periodically fetch exchange rate information.
    /// </summary>
    /// <param name="stoppingToken">The cancellation token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous execution operation.</returns>
    /// <remarks>
    /// This method is invoked periodically to fetch exchange rate information.
    /// The method uses the <c>IObtenerTipoCambioUseCase</c> to invoke the use case
    /// responsible for fetching exchange rate information.
    /// IServiceScopeFactory is used to create a service scope to access the use case.
    /// Allows inside the scope accessing the use case, DbContexts, and other dependencies, which are scoped to the lifetime of the service.
    /// </remarks>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = _scopeFactory.CreateScope();
                var userCaseActualizarTasa = scope.ServiceProvider.GetRequiredService<IActualizarTasaUseCase>();
                var useCaseObtenerTipoCambio = scope.ServiceProvider.GetRequiredService<IObtenerTipoCambioUseCase>();
                await userCaseActualizarTasa.Execute(stoppingToken);
                await useCaseObtenerTipoCambio.Execute(stoppingToken);
                await Task.Delay(TimeSpan.FromMinutes(3), stoppingToken);
            }
            catch (Exception ex)
            {
                await _logger.RegistrarLog(ex);
            }
            
        }
    }
}