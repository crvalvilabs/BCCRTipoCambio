namespace BCCR.TipoCambio.Domain.Excepciones;

/// <summary>
/// Represents an exception thrown when a rate is not registered
/// in the system or database where it is expected to be found.
/// </summary>
public class NotRegistrateRateException : Exception
{
    /// <summary>
    /// Represents an exception thrown when a required rate is not registered
    /// within the system or persists in the database during the operation.
    /// </summary>
    /// <example>
    /// Throw new NotRegistrateRateException();
    /// </example>
    public NotRegistrateRateException() : base()
    {
        
    }

    /// <summary>
    /// Represents an exception thrown when a required rate is not registered
    /// within the system or persists in the database during the operation.
    /// </summary>
    /// <example>
    /// Throw new NotRegistrateRateException("No se encontró la tasa de cambio para la fecha especificada");
    /// </example>
    public NotRegistrateRateException(string message) : base(message)
    {
        
    }
    
    /// <summary>
    /// Exception that is thrown when a rate is not found during a request operation.
    /// </summary>
    /// <example>
    /// Throw new NotRegistrateRateException("No se pudo registrar la tasa de cambio", ex);
    /// </example>
    public NotRegistrateRateException(string message, Exception innerException) : base(message, innerException)
    {
        
    }
}