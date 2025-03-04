using BreadOven.core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreadOven.Repository.Data.DataConfig
{
    public class Distributionfromitemconfig : IEntityTypeConfiguration<CostsAndDistrubutionfromitem>

    {
        public void Configure(EntityTypeBuilder<CostsAndDistrubutionfromitem> builder)
        {
            builder.Property(p => p.Percentage).HasPrecision(18, 3);
            builder.Property(p => p.DistCost).HasPrecision(18, 4);
            builder.Property(p => p.Cost).HasPrecision(18, 4);
            // builder.Property(p => p.TotalOperatingSalary).HasPrecision(18, 4);




        }
    }
}
