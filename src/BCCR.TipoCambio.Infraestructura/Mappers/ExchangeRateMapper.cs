using BCCR.TipoCambio.Domain.Entities;
using BCCR.TipoCambio.Infraestructura.Entities;

namespace BCCR.TipoCambio.Infraestructura.Mappers;

/// <summary>
/// Provides methods for mapping exchange rate domain entities to infrastructure entities.
/// This is used to transform data between domain-level and database-level representations.
/// </summary>
public class ExchangeRateMapper
{
    /// <summary>
    /// Maps a domain-level exchange rate entity to an infrastructure-level exchange rate entity.
    /// This method is used for transforming business domain objects into database entities
    /// for persistence operations.
    /// </summary>
    /// <param name="exchangeRate">
    /// The domain-level exchange rate entity to be mapped.
    /// It contains details such as exchange date, currencies, buy rate, sell rate, and active status.
    /// </param>
    /// <returns>
    /// An infrastructure-level exchange rate entity that can be used for database operations.
    /// </returns>
    public ExchangeRateEntity MapToEntity(ExchangeRate exchangeRate)
    {
        var entity = new ExchangeRateEntity
        {
            ExchangeDate = exchangeRate.ExchangeDate,
            FromCurrency = exchangeRate.FromCurrency,
            ToCurrency = exchangeRate.ToCurrency,
            Buy = exchangeRate.Buy,
            Sell = exchangeRate.Sell,
            IsActive = exchangeRate.IsActive
        };
        
        return entity;
    }
}