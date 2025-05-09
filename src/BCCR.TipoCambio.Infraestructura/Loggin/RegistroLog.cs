using Microsoft.Extensions.Configuration;
using BCCR.TipoCambio.Aplicacion.Interfaces;

namespace BCCR.TipoCambio.Infraestructura.Loggin;

/// <summary>
/// Provides functionality for logging exception details into a file.
/// </summary>
public class RegistroLog : IRegistroLog
{
    /// <summary>
    /// Provides access to configuration settings for the application.
    /// The configuration is used to retrieve settings such as file paths or other application-specific parameters,
    /// typically sourced from appsettings.json or environment variables.
    /// </summary>
    private readonly IConfiguration _configuration;

    /// <summary>
    /// A class that provides functionality to log exceptions into a file, including details
    /// such as the exception message, inner exception, and source along with a timestamp.
    /// </summary>
    public RegistroLog(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// Logs the details of an exception into a file, including information such as
    /// the exception message, inner exception, source, and a timestamp.
    /// </summary>
    /// <param name="excepcion">The exception object containing details to be logged.</param>
    /// <returns>A task representing the asynchronous operation of logging the exception.</returns>
    public async Task RegistrarLog(dynamic excepcion)
    {
        var (fechaHora, fecha) = ObtenerFechaHora();
        var mensaje = ObtenerMensaje(excepcion, fechaHora);
        var nombreArchivo = CrearNombreArchivo();
        await EscribirLog(nombreArchivo, mensaje);
    }

    /// <summary>
    /// Retrieves the current date and time, returning it in two formats: full date-time
    /// and date-only. This can be used for timestamping purposes in logging or other operations.
    /// </summary>
    /// <returns>
    /// A tuple containing the formatted current date and time as a string ("dd/MM/yyyy HH:mm:ss")
    /// in the first position and the date-only component ("dd/MM/yyyy") in the second position.
    /// </returns>
    private Tuple<string, string> ObtenerFechaHora()
    {
        var fechaHora = DateTime.Now;
        var tuple = new Tuple<string, string>(fechaHora.ToString("dd/MM/yyyy HH:mm:ss"),
            fechaHora.ToString("dd/MM/yyyy"));
        return tuple;
    }

    /// <summary>
    /// Generates a formatted message string containing details about the provided exception, including the error message,
    /// inner exception, source, and timestamp.
    /// </summary>
    /// <param name="excepcion">The exception object containing the relevant details to be included in the message.</param>
    /// <param name="fechaHora">The formatted timestamp indicating when the exception occurred.</param>
    /// <returns>A string containing the formatted exception details.</returns>
    private string ObtenerMensaje(dynamic excepcion, string fechaHora)
    {
        var mensaje = string.Format("{0} : \nError: {1} \nException: {2} \nSource: {3}",
            fechaHora, 
            excepcion.Message, 
            excepcion.InnerException,
            excepcion.Source);
        return mensaje;
    }

    /// <summary>
    /// Generates the full path for the log file by combining the configuration-defined
    /// directory path and file name into a string.
    /// </summary>
    /// <returns>A string representing the full path and name of the log file.</returns>
    private string CrearNombreArchivo()
    {
        var rutaArchivo = _configuration.GetSection("RegistroLog:RutaArchivo").Value;
        var nombreArchivo = _configuration.GetSection("RegistroLog:NombreArchivo").Value;
        var nombre = string.Format("{0}\\{1}.txt", rutaArchivo, nombreArchivo);
        return nombre;
    }

    /// <summary>
    /// Writes log messages to a specified file asynchronously.
    /// </summary>
    /// <param name="nombreArchivo">The full path or name of the file where the log will be written.</param>
    /// <param name="mensaje">The content of the log message to be written to the file.</param>
    /// <returns>A task representing the asynchronous operation of writing the log message to the file.</returns>
    private async Task EscribirLog(string nombreArchivo, string mensaje)
    {
        await using var writer = new StreamWriter(nombreArchivo, true);
        await writer.WriteLineAsync(mensaje);
        await writer.FlushAsync();
        writer.Close();
    }
}