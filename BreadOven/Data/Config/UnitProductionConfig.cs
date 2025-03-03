using BreadOven.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreadOven.Data.Config
{
    public class UnitProductionConfig : IEntityTypeConfiguration<UnitProduction>
    {
        public void Configure(EntityTypeBuilder<UnitProduction> builder)
        {

            builder.Property(p => p.OperatingHoursQuantity).HasColumnType("decimal(18,4)");
            builder.Property(p => p.UnitValue).HasColumnType("decimal(18,4)");
            builder.Property(p => p.Price).HasColumnType("decimal(18,4)");
        }
    }
}
