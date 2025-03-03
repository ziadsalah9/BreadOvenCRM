using BreadOven.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace BreadOven.Data.Config
{
    public class Costsconfig : IEntityTypeConfiguration<Costs>
    {
        public void Configure(EntityTypeBuilder<Costs> builder)
        {

            builder.Property(p => p.Cost).HasColumnType("decimal(18,3)");
            //    builder .Property(e => e.Type)
            //   .HasConversion(
            //       v => v.ToString(),
            //       v => (TypeOfCost)Enum.Parse(typeof(TypeOfCost), v));
            //}
        }
    }
}