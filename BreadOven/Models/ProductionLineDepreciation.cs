using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace BreadOven.Models
{
    public class ProductionLineDepreciation
    {



        public int Id { get; set; }
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
