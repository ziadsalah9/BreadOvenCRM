using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace BreadOven.core.Models
{
    public class ProductionLineDepreciation :BaseEntity
    {



        public string Name { get; set; }

        public int ProductionAgeYear { get; set; }

        public decimal OriginalValue { get; set; }

        public string ValuePercentage { get; set; }

        public decimal valueYear { get; set; }
        public decimal valueMonth { get; set; }
        public decimal valueDay { get; set; }

        public decimal valueHour { get; set; }

    }
}
