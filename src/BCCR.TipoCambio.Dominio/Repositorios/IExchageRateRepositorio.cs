using BCCR.TipoCambio.Domain.Entities;

namespace BCCR.TipoCambio.Domain.Repositorios;

/// <summary>
/// Defines the contract for an exchange rate repository within the domain.
/// This repository handles operations related to the persistence of exchange rate data.
/// </summary>
public interface IExchageRateRepositorio
{
    /// <summary>
    /// Registers a new exchange rate in the repository.
    /// This operation involves mapping the domain exchange rate data to a database entity,
    /// adding it to the database context, and saving the changes.
    /// </summary>
    /// <param name="exchangeRate">The exchange rate entity containing details such as date, currencies, buying rate, and selling rate.</param>
    /// <param name="cancellationToken">The cancellation token to monitor for cancellation requests during the operation.</param>
    Task RegistrarTipoCambio(ExchangeRate exchangeRate, CancellationToken cancellationToken);
    
    /// <summary>
    /// Updates the state of the default exchange rate by setting its IsActive property to false
    /// and persists the changes to the database.
    /// </summary>
    /// <param name="cancellationToken">A token to observe for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task ActualizarEstado(CancellationToken cancellationToken);
}