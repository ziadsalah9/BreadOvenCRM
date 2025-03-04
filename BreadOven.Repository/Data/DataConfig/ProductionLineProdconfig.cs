
using BreadOven.core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreadOven.Repository.Data.DataConfig
{
    public class ProductionLineProdconfig : IEntityTypeConfiguration<ProductionLineDepreciation>
    {
        public void Configure(EntityTypeBuilder<ProductionLineDepreciation> builder)
        {
            builder.Property(p => p.OriginalValue).HasPrecision(18, 3);
            builder.Property(p => p.valueYear).HasPrecision(18, 3);
            builder.Property(p => p.valueMonth).HasPrecision(18, 3);
            builder.Property(p => p.valueDay).HasPrecision(18, 3);
            builder.Property(p => p.valueHour).HasPrecision(18, 3);


        }
    }
}
