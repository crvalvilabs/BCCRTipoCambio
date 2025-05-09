namespace BCCR.TipoCambio.Domain.Excepciones;

/// <summary>
/// Represents an exception thrown when an attempt to update the exchange rate fails.
/// </summary>
public class NotUpdateRateException : Exception
{
    /// <summary>
    /// Represents an exception thrown when an update to the exchange rate cannot be performed.
    /// </summary>
    /// <remarks>
    /// This constructor initializes the exception with no message.
    /// </remarks>
    public NotUpdateRateException() : base()
    {
        
    }

    /// <summary>
    /// Represents an exception thrown when an attempt to update the exchange rate fails.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <remarks>
    /// This constructor initializes the exception with the specified message.
    /// </remarks>
    public NotUpdateRateException(string message) : base(message)
    {
        
    }

    /// <summary>
    /// Represents an exception thrown when an update to the exchange rate cannot be performed.
    /// </summary>
    /// <remarks>
    /// This constructor initializes the exception with no message.
    /// </remarks>
    public NotUpdateRateException(string message, Exception innerException) : base(message, innerException)
    {
        
    }
}