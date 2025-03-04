using System.ComponentModel.DataAnnotations.Schema;

namespace BreadOven.core.Models
{
    public class Item :BaseEntity
    {

        public string Name { get; set; }

        public decimal EnergyReq { get; set; }

        public int OperatingHours { get; set; }

        public decimal Totalvalueofhoursdeprication { get; set; }


        public decimal HourlyOperatingRate { get; set; }   //OperatingHours/EnegryReq 


        [ForeignKey("FactoryLines")]
        public int factoryLinesId { get; set; }
        public FactoryLines FactoryLines{  get; set; }


        //[ForeignKey("productionLineDepreciation")]
        //public int productionlinedepricationId { get; set; }
        //public ProductionLineDepreciation productionLineDepreciation { get; set; }
    }
}
