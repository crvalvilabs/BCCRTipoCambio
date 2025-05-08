using BCCR.TipoCambio.Application.Interfaces;

namespace BCCR.TipoCambio.ServicioWindows;

/// <summary>
/// Represents a background service that periodically fetches exchange rate information
/// by invoking the corresponding use case.
/// </summary>
public class Worker : BackgroundService
{
    /// <summary>
    /// Holds the use case instance responsible for fetching exchange rate information.
    /// </summary>
    private readonly IObtenerTipoCambioUseCase _obtenerTipoCambioUseCase;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Worker"/> class.
    /// </summary>
    /// <param name="obtenerTipoCambioUseCase"></param>
    public Worker(IObtenerTipoCambioUseCase obtenerTipoCambioUseCase)
    {
        _obtenerTipoCambioUseCase = obtenerTipoCambioUseCase;
    }
    
    /// <summary>
    /// Executes the background service's main logic.
    /// This method periodically invokes the use case to fetch exchange rate information
    /// and waits for the specified time interval before invoking the use case again.
    /// This method is called by the framework when the service starts.
    /// </summary>
    /// <param name="stoppingToken">The cancellation token used to cancel the background service.</param>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await _obtenerTipoCambioUseCase.Execute(stoppingToken);
            await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
        }
    }
}