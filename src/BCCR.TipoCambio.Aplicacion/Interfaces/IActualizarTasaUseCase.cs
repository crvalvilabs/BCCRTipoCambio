namespace BCCR.TipoCambio.Aplicacion.Interfaces;

/// <summary>
/// Defines a contract for the use case responsible for updating exchange rate data.
/// </summary>
public interface IActualizarTasaUseCase
{
    /// <summary>
    /// Executes the process of updating the exchange rate data.
    /// This method is responsible for coordinating the steps necessary to fetch, process,
    /// and persist updated exchange rate information in the system.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation if required.</param>
    /// <returns>A Task representing the asynchronous operation.</returns>
    Task Execute(CancellationToken cancellationToken);
}