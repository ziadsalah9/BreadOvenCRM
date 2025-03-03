using BreadOven.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreadOven.Data.Config
{
    public class ProductionLineProdconfig : IEntityTypeConfiguration<ProductionLineDepreciation>
    {
        public void Configure(EntityTypeBuilder<ProductionLineDepreciation> builder)
        {
            builder.Property(p => p.OriginalValue).HasColumnType("decimal(18,3)");
            builder.Property(p => p.valueYear).HasColumnType("decimal(18,3)");
            builder.Property(p => p.valueMonth).HasColumnType("decimal(18,3)");
            builder.Property(p => p.valueDay).HasColumnType("decimal(18,2)");
            builder.Property(p => p.valueHour).HasColumnType("decimal(18,2)");

        }
    }
}
