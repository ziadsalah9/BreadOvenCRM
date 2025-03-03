using BreadOven.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreadOven.Data.Config
{
    public class ItemConifg : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.Property(p=>p.EnergyReq).HasColumnType("decimal(18,2)"); 
            builder.Property(p=>p.Totalvalueofhoursdeprication).HasColumnType("decimal(18,2)");
            builder.Property(p=>p.HourlyOperatingRate).HasColumnType("decimal(18,2)");
        }
    }
}
