namespace BCCR.TipoCambio.ServicioWindows;

public class Worker : BackgroundService
{
    public Worker()
    {
        
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {

        }
    }
}