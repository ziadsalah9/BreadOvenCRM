using Microsoft.EntityFrameworkCore;

namespace BreadOven.Models
{
    public class StoreContext : DbContext 
    {


        public StoreContext(DbContextOptions<StoreContext>options):base(options)
        {
            
        }
        public DbSet<ProductionLineDepreciation> ProductionLineDepreciations { get; set; }
        public DbSet<FactoryLines> FactoryLines { get; set; }
        public DbSet<Item> items { get; set; }

        public DbSet<Distrubutionfromitem> Distrubutionfromitems { get; set; }

        public DbSet<Costs> typeOfCosts { get; set; }

        public DbSet<UnitProduction> unitProductions  { get; set; }




    }
}
