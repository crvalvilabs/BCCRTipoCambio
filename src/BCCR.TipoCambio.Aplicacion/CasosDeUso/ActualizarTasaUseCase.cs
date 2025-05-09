using BCCR.TipoCambio.Aplicacion.Interfaces;
using BCCR.TipoCambio.Domain.Entities;
using BCCR.TipoCambio.Domain.Repositorios;

namespace BCCR.TipoCambio.Aplicacion.CasosDeUso;

/// <summary>
/// Represents a use case for updating the exchange rate data.
/// This class coordinates the interaction between the repository and the service
/// responsible for fetching and persisting the exchange rate information.
/// </summary>
public class ActualizarTasaUseCase : IActualizarTasaUseCase
{
    /// <summary>
    /// Represents the repository interface responsible for exchange rate operations,
    /// used to persist and manage exchange rate data within the system.
    /// Acts as a dependency for the ActualizarTasaUseCase to provide functionality
    /// such as registering and updating exchange rate states.
    /// </summary>
    private readonly IExchageRateRepositorio _exchageRateRepositorio;

    /// <summary>
    /// Represents a use case for updating the exchange rate data.
    /// Coordinates the interaction between the repository and the logic
    /// responsible for persisting exchange rate information.
    /// </summary>
    public ActualizarTasaUseCase(IExchageRateRepositorio exchageRateRepositorio)
    {
        _exchageRateRepositorio = exchageRateRepositorio;
    }

    /// <summary>
    /// Executes the process of updating the exchange rate data.
    /// This method is responsible for coordinating the steps necessary to fetch, process,
    /// and persist updated exchange rate information in the system.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation if required.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task Execute(CancellationToken cancellationToken)
    {
        await _exchageRateRepositorio.ActualizarEstado(cancellationToken);
    }
}