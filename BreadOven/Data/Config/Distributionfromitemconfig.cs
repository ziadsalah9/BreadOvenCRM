using BreadOven.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreadOven.Data.Config
{
    public class Distributionfromitemconfig : IEntityTypeConfiguration<Distrubutionfromitem>

    {
        public void Configure(EntityTypeBuilder<Distrubutionfromitem> builder)
        {     
            
            builder.Property(p=>p.Percentage).HasColumnType("decimal(18,2)");
            builder.Property(p => p.FixedSalary).HasColumnType("decimal(18,3)");
            builder.Property(p => p.VariableSalary).HasColumnType("decimal(18,3)");
            builder.Property(p => p.TotalOperatingSalary).HasColumnType("decimal(18,3)");
                

        }
    }
}
