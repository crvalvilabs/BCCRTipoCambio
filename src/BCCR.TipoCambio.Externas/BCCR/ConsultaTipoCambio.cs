using System.Globalization;
using System.Xml.Linq;
using BCCR.TipoCambio.Domain.Excepciones;
using BCCR.TipoCambio.Domain.Servicios;
using Microsoft.Extensions.Configuration;

namespace BCCR.TipoCambio.Externas.BCCR;

/// <summary>
/// Provides methods to retrieve exchange rate data from the BCCR (Banco Central de Costa Rica) service.
/// </summary>
public class ConsultaTipoCambio : IConsultaTipoCambio
{
    /// <summary>
    /// HttpClient used to make requests to the BCCR service.
    /// </summary>
    private readonly HttpClient _httpClient;
    
    /// <summary>
    /// Configuration used to retrieve the necessary information to make requests to the BCCR service.
    /// </summary>
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Provides methods to retrieve and process exchange rate information
    /// from the Banco Central de Costa Rica (BCCR) service.
    /// </summary>
    public ConsultaTipoCambio(IConfiguration configuration, HttpClient httpClient)
    {
        _configuration = configuration;
        _httpClient = httpClient;
    }

  
    public async Task<Tuple<decimal, string>>  ConsultaCompra()
    {
        try
        {
            var url = _configuration.GetSection("BCCR:Url").Value;
            var fecha = DateTime.Now.ToString("dd/MM/yyyy");

            var content = new FormUrlEncodedContent([
                new KeyValuePair<string, string?>("Indicador", _configuration.GetSection("BCCR:IndicadorCompra").Value),
                new KeyValuePair<string, string?>("FechaInicio", fecha),
                new KeyValuePair<string, string?>("FechaFinal", fecha),
                new KeyValuePair<string, string?>("Nombre", _configuration.GetSection("BCCR:Nombre").Value),
                new KeyValuePair<string, string?>("SubNiveles", _configuration.GetSection("BCCR:SubNiveles").Value),
                new KeyValuePair<string, string?>("CorreoElectronico", _configuration.GetSection("BCCR:Email").Value),
                new KeyValuePair<string, string?>("Token", _configuration.GetSection("BCCR:Token").Value)
            ]);

            var response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

            var xmlContent = await response.Content.ReadAsStringAsync();
            var xml = XDocument.Parse(xmlContent);

            var rateValue = xml.Descendants(_configuration.GetSection("BCCR:Descendants").Value!)
                .FirstOrDefault()?
                .Element(_configuration.GetSection("BCCR:Num").Value!)?
                .Value;

            var dateValue = xml.Descendants(_configuration.GetSection("BCCR:Descendants").Value!)
                .FirstOrDefault()?
                .Element(_configuration.GetSection("BCCR:Des").Value!)?
                .Value;
            
            if (!DateTimeOffset.TryParse(dateValue, out var dto))
            {
                throw new NotFoundRateException("Fecha no válida en el XML.");
            }
            var formatDate = dto.DateTime;

            var rate = decimal.Parse(rateValue!, CultureInfo.InvariantCulture);

            return new Tuple<decimal, string>(rate, formatDate.ToString("dd/MM/yyyy"));

        }
        catch (Exception)
        {
            throw new NotFoundRateException("No se pudo obtener el tipo de cambio de compra del XML.");
        }
    }

    
    public async Task<Tuple<decimal, string>> ConsultaVenta()
    {
        try
        {
            var url = _configuration.GetSection("BCCR:Url").Value;
            var fecha = DateTime.Now.ToString("dd/MM/yyyy");

            var content = new FormUrlEncodedContent([
                new KeyValuePair<string, string?>("Indicador", _configuration.GetSection("BCCR:IndicadorVenta").Value),
                new KeyValuePair<string, string?>("FechaInicio", fecha),
                new KeyValuePair<string, string?>("FechaFinal", fecha),
                new KeyValuePair<string, string?>("Nombre", _configuration.GetSection("BCCR:Nombre").Value),
                new KeyValuePair<string, string?>("SubNiveles", _configuration.GetSection("BCCR:SubNiveles").Value),
                new KeyValuePair<string, string?>("CorreoElectronico", _configuration.GetSection("BCCR:Email").Value),
                new KeyValuePair<string, string?>("Token", _configuration.GetSection("BCCR:Token").Value)
            ]);

            var response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

            var xmlContent = await response.Content.ReadAsStringAsync();
            var xml = XDocument.Parse(xmlContent);

            var rateValue = xml.Descendants(_configuration.GetSection("BCCR:Descendants").Value!)
                .FirstOrDefault()?
                .Element(_configuration.GetSection("BCCR:Num").Value!)?
                .Value;

            var dateValue = xml.Descendants(_configuration.GetSection("BCCR:Descendants").Value!)
                .FirstOrDefault()?
                .Element(_configuration.GetSection("BCCR:Des").Value!)?
                .Value;
            
            if (!DateTimeOffset.TryParse(dateValue, out var dto))
            {
                throw new NotFoundRateException("Fecha no válida en el XML.");
            }
            var formatDate = dto.DateTime;
            
            var rate = decimal.Parse(rateValue!, CultureInfo.InvariantCulture);
            
            return new Tuple<decimal, string>(rate, formatDate.ToString("dd/MM/yyyy"));
        }
        catch (Exception)
        {
            throw new NotFoundRateException("No se pudo obtener el tipo de cambio de venta del XML.");       
        }
    }
    
}

