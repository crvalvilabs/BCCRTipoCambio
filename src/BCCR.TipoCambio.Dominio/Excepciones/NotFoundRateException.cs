namespace BCCR.TipoCambio.Domain.Excepciones;

/// <summary>
/// Represents an exception thrown when a requested exchange rate is not found.
/// </summary>
public class NotFoundRateException : Exception
{
    /// <summary>
    /// Exception that is thrown when an exchange rate is not found during a request operation.
    /// </summary>
    public NotFoundRateException(string message) : base(message)
    {
    }
}