using BCCR.TipoCambio.Domain.Entities;
using BCCR.TipoCambio.Domain.Repositorios;
using BCCR.TipoCambio.Infraestructura.Database;
using BCCR.TipoCambio.Infraestructura.Mappers;

namespace BCCR.TipoCambio.Infraestructura.Repositorios;

public class ExchangeRateRepositorio : IExchageRateRepositorio
{
    /// <summary>
    /// Represents the instance of <see cref="NubaHotelContext"/> used to interact
    /// with the Nuba Hotel database in the infrastructure layer. Provides access
    /// to database operations such as querying and persisting exchange rates and
    /// other related entities.
    /// </summary>
    private readonly NubaHotelContext _nubaHotelContext;
    
    /// <summary>
    /// Represents the instance of <see cref="ExchangeRateMapper"/> used to map
    /// exchange rates between the domain and infrastructure layers.
    /// Provides methods for mapping between the two layers.
    /// </summary>
    private readonly ExchangeRateMapper _exchangeRateMapper;

    /// <summary>
    /// Provides the implementation of the <see cref="IExchageRateRepositorio"/> interface.
    /// This repository handles operations related to the exchange rate, including
    /// data persistence and retrieval from the Nuba Hotel database.
    /// </summary>
    public ExchangeRateRepositorio(NubaHotelContext nubaHotelContext, ExchangeRateMapper exchangeRateMapper)
    {
        _exchangeRateMapper = exchangeRateMapper;
        _nubaHotelContext = nubaHotelContext;
    }

    /// <summary>
    /// Registers a new exchange rate in the database.
    /// Maps the exchange rate domain entity to a database entity, adds it to the database context, and persists the changes.
    /// </summary>
    /// <param name="exchangeRate">The exchange rate information to be registered, including details like currencies, rates, and date.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>Returns a task containing a boolean value indicating whether the operation was successful.</returns>
    public async Task<bool> RegistrarTipoCambio(ExchangeRate exchangeRate, CancellationToken cancellationToken)
    {
        var exchangeRateEntity = _exchangeRateMapper.MapToEntity(exchangeRate);
        await _nubaHotelContext.ExchangeRates.AddAsync(exchangeRateEntity, cancellationToken);
        return await _nubaHotelContext.SaveChangesAsync(cancellationToken) > 0;
    }
}