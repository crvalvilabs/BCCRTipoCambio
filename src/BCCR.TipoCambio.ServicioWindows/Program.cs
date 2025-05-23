using BCCR.TipoCambio.Aplicacion;
using BCCR.TipoCambio.ServicioWindows;
using BCCR.TipoCambio.Infraestructura;
using BCCR.TipoCambio.Externas;


var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddWindowsService(opt =>
{
    opt.ServiceName = "BCCR Tipo de Cambio";
});

// Add services to the container.
builder.Services.AddInfraestructura(builder.Configuration)
    .AddExternas()
    .AddServicioWindows()
    .AddAplicacion();

var host = builder.Build();
host.Run();