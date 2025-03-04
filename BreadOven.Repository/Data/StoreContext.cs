using BreadOven.core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadOven.Repository.Data
{
    public class StoreContext :DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }
        public DbSet<ProductionLineDepreciation> ProductionLineDepreciations { get; set; }
        public DbSet<FactoryLines> FactoryLines { get; set; }
        public DbSet<Item> items { get; set; }

        public DbSet<CostsAndDistrubutionfromitem> CostsAndDistrubutionfromitems { get; set; }

        //public DbSet<Costs> typeOfCosts { get; set; }

        public DbSet<UnitProduction> unitProductions { get; set; }
    }
}
