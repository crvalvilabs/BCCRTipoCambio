using BCCR.TipoCambio.Aplicacion.Interfaces;
using BCCR.TipoCambio.Domain.Repositorios;
using BCCR.TipoCambio.Domain.Entities;
using BCCR.TipoCambio.Domain.Servicios;

namespace BCCR.TipoCambio.Aplicacion.CasosDeUso;

/// <summary>
/// Represents a use case for retrieving and saving the exchange rate data.
/// This class coordinates the interaction between the repository and the service
/// responsible for fetching and persisting the exchange rate information.
/// </summary>
public class ObtenerTipocambioUseCase : IObtenerTipoCambioUseCase
{
    /// <summary>
    /// Repository dependency that provides data access operations related to
    /// exchange rate persistence. This variable is injected to handle
    /// interactions with the datastore for storing exchange rate information.
    /// </summary>
    private readonly IExchageRateRepositorio _exchageRateRepositorio;

    /// <summary>
    /// Service dependency used to query the exchange rate for purchase and sale operations.
    /// This variable interacts with an implementation of IConsultaTipoCambio to retrieve
    /// exchange rate details, including the rate value and associated date.
    /// </summary>
    private readonly IConsultaTipoCambio _consultaTipoCambio;

    /// <summary>
    /// Represents the use case for getting the exchange rate by interacting with
    /// external services and saving the retrieved data to the repository.
    /// </summary>
    public ObtenerTipocambioUseCase(IExchageRateRepositorio exchageRateRepositorio,
        IConsultaTipoCambio consultaTipoCambio)
    {
        _exchageRateRepositorio = exchageRateRepositorio;
        _consultaTipoCambio = consultaTipoCambio;
    }

    /// <summary>
    /// Executes the use case for retrieving exchange rate data by consulting external services
    /// and saving the fetched information into the repository.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to monitor for cancellation requests.</param>
    public async Task Execute(CancellationToken cancellationToken)
    {   
        var tipoCambioCompra = await _consultaTipoCambio.ConsultaCompra();
        var tipoCambioVenta = await _consultaTipoCambio.ConsultaVenta();
        
        var exchangeRate = new ExchangeRate
        {
            ExchangeDate = Convert.ToDateTime(tipoCambioCompra.Item2),
            FromCurrency = "CRC",
            ToCurrency = "USD",
            Buy = tipoCambioCompra.Item1,
            Sell = tipoCambioVenta.Item1,
            IsActive = true
        };
        
        await _exchageRateRepositorio.RegistrarTipoCambio(exchangeRate, CancellationToken.None);
    }
}