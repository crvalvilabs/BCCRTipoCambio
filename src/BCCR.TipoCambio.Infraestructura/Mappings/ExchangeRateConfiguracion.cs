using BCCR.TipoCambio.Infraestructura.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BCCR.TipoCambio.Infraestructura.Mappings;

/// <summary>
/// Configures the entity mapping for the <c>ExchangeRateEntity</c> class.
/// This configuration defines how the <c>ExchangeRateEntity</c> is mapped to the database using Entity Framework.
/// </summary>
/// <remarks>
/// This class specifies the table name, schema, primary key, and column configurations
/// such as data types and column names for the <c>ExchangeRateEntity</c>.
/// </remarks>
public class ExchangeRateConfiguracion
{
    public ExchangeRateConfiguracion(EntityTypeBuilder<ExchangeRateEntity> builder)
    {
        builder.ToTable(name: "ExchangeRate", schema: "Hotel");
        builder.HasKey(x => x.RateId)
            .HasName("PK_ExchangeRate");
        builder.Property(x => x.RateId).ValueGeneratedOnAdd();
        builder.Property(x => x.ExchangeDate).HasColumnName("ExchangeDate")
            .HasColumnType("datetime");
        builder.Property(x => x.FromCurrency).HasColumnName("FromCurrency")
            .HasColumnType("varchar(10)");
        builder.Property(x => x.ToCurrency).HasColumnName("ToCurrency")
            .HasColumnType("varchar(10)");
        builder.Property(x => x.Buy).HasColumnName("Buy")
            .HasColumnType("decimal(6, 2)");
        builder.Property(x => x.Sell).HasColumnName("Sell")
            .HasColumnType("decimal(6, 2)");
        builder.Property(x => x.IsActive).HasColumnName("IsActive")
            .HasColumnType("bit");
    }
}