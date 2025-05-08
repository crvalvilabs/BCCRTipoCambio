using BCCR.TipoCambio.Infraestructura.Entities;
using Microsoft.EntityFrameworkCore;
using BCCR.TipoCambio.Infraestructura.Mappings;

namespace BCCR.TipoCambio.Infraestructura.Database;

/// <summary>
/// Represents the context for the Nuba Hotel database.
/// </summary>
public class NubaHotelContext : DbContext
{
    /// <summary>
    /// The DbSet for the ExchangeRate entity.
    /// </summary>
    public DbSet<ExchangeRateEntity> ExchangeRates {get;set;}
    
    /// <summary>
    /// Initializes a new instance of the <see cref="NubaHotelContext"/> class.
    /// </summary>
    /// <param name="options">The options for the context.</param>
    public NubaHotelContext(DbContextOptions<NubaHotelContext> options) : base(options)
    {
        
    }

    /// <summary>
    /// Configures the model for the database context by defining entity relationships, keys, and constraints.
    /// </summary>
    /// <param name="modelBuilder">The builder used to construct the model for the context.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        ConfigureEntities(modelBuilder);
    }

    /// <summary>
    /// Configures the entity mappings for the Entity Framework model builder.
    /// </summary>
    /// <param name="modelBuilder">The model builder used to configure entity mappings.</param>
    private void ConfigureEntities(ModelBuilder modelBuilder)
    {
        var exchangeRate = new ExchangeRateConfiguracion(modelBuilder.Entity<ExchangeRateEntity>());
    }
}