
using BreadOven.core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreadOven.Repository.Data.DataConfig
{
    public class UnitProductionConfig : IEntityTypeConfiguration<UnitProduction>
    {
        public void Configure(EntityTypeBuilder<UnitProduction> builder)
        {

            builder.Property(p => p.OperatingHoursQuantity).HasPrecision(18, 4);
            builder.Property(p => p.UnitValue).HasPrecision(18, 4);
            builder.Property(p => p.Price).HasPrecision(18, 4);

                  }
    }
}
