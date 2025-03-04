using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreadOven.core.Models
{
    public class UnitProduction :BaseEntity
    {




        public decimal OperatingHoursQuantity { get; set; }   

        public string  unitType { get; set; }
        
        public decimal UnitValue { get; set; }     //  unit price from the costs * operating hoursquanitiy 

    
        public decimal Price { get; set; }




        //[ForeignKey("Item")]
        //public int ItemId { get; set; }
        //public Item Item { get; set; }


        [ForeignKey(nameof(CostsAndDistrubutionfromitem))]
        public int costsAndDistributionId { get; set; }

        public CostsAndDistrubutionfromitem CostsAndDistrubutionfromitem{ get; set; }

    }
}
