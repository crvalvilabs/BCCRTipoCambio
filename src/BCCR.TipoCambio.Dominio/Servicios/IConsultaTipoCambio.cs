using BCCR.TipoCambio.Domain.Entities;

namespace BCCR.TipoCambio.Domain.Servicios;

/// <summary>
/// Provides the contract for retrieving currency exchange rates, including
/// methods for obtaining the purchase and sale exchange rates.
/// </summary>
public interface IConsultaTipoCambio
{
    /// <summary>
    /// Retrieves the current purchase exchange rate along with the date of the rate.
    /// </summary>
    /// <returns>A tuple containing the purchase exchange rate as a decimal and the associated date as a string.</returns>
    Task<Tuple<decimal, string>> ConsultaCompra();

    /// <summary>
    /// Retrieves the current sale exchange rate along with the date of the rate.
    /// </summary>
    /// <returns>A tuple containing the sale exchange rate as a decimal and the associated date as a string.</returns>
    Task<Tuple<decimal, string>> ConsultaVenta();
}