using BreadOven.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreadOven.Data.Config
{
    public class Distributionfromitemconfig : IEntityTypeConfiguration<CostsAndDistrubutionfromitem>

    {
        public void Configure(EntityTypeBuilder<CostsAndDistrubutionfromitem> builder)
        {     
            
            builder.Property(p=>p.Percentage).HasColumnType("decimal(18,3)").HasPrecision(18, 3);
            builder.Property(p => p.DistCost).HasColumnType("decimal(18,4)").HasPrecision(18, 4);
            builder.Property(p => p.Cost).HasColumnType("decimal(18,4)").HasPrecision(18, 4);
           // builder.Property(p => p.TotalOperatingSalary).HasColumnType("decimal(18,4)").HasPrecision(18, 4);



        }
    }
}
