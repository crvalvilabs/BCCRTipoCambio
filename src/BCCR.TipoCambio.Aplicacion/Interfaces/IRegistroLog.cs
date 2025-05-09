namespace BCCR.TipoCambio.Aplicacion.Interfaces;

/// <summary>
/// Defines a contract for logging-related operations within an application.
/// </summary>
public interface IRegistroLog
{
    /// <summary>
    /// Logs the details of an exception into a file, including an exception message,
    /// inner exception, source, and a timestamp.
    /// </summary>
    /// <param name="excepcion">The exception object containing details to be logged.</param>
    Task RegistrarLog(dynamic excepcion);
}