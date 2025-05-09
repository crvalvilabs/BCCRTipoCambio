namespace BCCR.TipoCambio.Aplicacion.Interfaces;

/// <summary>
/// Defines the contract for collecting the exchange rate information.
/// </summary>
public interface IObtenerTipoCambioUseCase
{
    /// <summary>
    /// Executes the use case to collect the exchange rate information.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to monitor for cancellation requests.</param>
    Task Execute(CancellationToken cancellationToken);
}