
using BreadOven.core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreadOven.Repository.Data.DataConfig
{
    public class ItemConifg : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.Property(p => p.EnergyReq).HasPrecision(18, 2);
            builder.Property(p => p.Totalvalueofhoursdeprication).HasPrecision(18, 2);
            builder.Property(p => p.HourlyOperatingRate).HasPrecision(18, 2);

        }
    }
}
