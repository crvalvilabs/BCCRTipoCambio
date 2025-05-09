namespace BCCR.TipoCambio.Domain.Excepciones;

/// <summary>
/// Represents an exception thrown when a requested exchange rate is not found.
/// </summary>
public class NotFoundRateException : Exception
{
    /// <summary>
    /// Represents an exception thrown when a requested exchange rate could not be found.
    /// </summary>
    public NotFoundRateException() : base()
    {
        
    }
    
    /// <summary>
    /// Exception that is thrown when an exchange rate is not found during a request operation.
    /// </summary>
    public NotFoundRateException(string message) : base(message)
    {
        
    }
    
    /// <summary>
    /// Exception that is thrown when an exchange rate is not found during a request operation.
    /// </summary>
    public NotFoundRateException(string message, Exception innerException) : base(message, innerException)
    {
    }
}