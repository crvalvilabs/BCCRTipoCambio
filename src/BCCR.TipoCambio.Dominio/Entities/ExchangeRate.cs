namespace BCCR.TipoCambio.Domain.Entities;

/// <summary>
/// Represents the exchange rate between two currencies.
/// This class includes information such as the rate ID, the date of the exchange,
/// the currencies being converted, the buying and selling rates,
/// and whether the rate is currently active.
/// </summary>
public class ExchangeRate
{
    /// <summary>
    /// The unique identifier for the exchange rate.
    /// </summary>
    public int RateId {get;set;}
    
    /// <summary>
    /// The date of the exchange rate.
    /// </summary>
    public DateTime ExchangeDate  {get;set;}
    
    /// <summary>
    /// The currencies being converted.
    /// </summary>
    public string? FromCurrency {get;set;}
    
    /// <summary>
    /// The currencies being converted.
    /// </summary>
    public string? ToCurrency {get;set;}
    
    /// <summary>
    /// The buying and selling rates.
    /// </summary>
    public decimal Buy {get;set;}
    
    /// <summary>
    /// The buying and selling rates.
    /// </summary>
    public decimal Sell {get;set;}
    
    /// <summary>
    /// Whether the exchange rate is currently active.
    /// </summary>
    public bool IsActive {get;set;}
}