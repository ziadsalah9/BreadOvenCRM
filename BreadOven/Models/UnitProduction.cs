using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreadOven.Models
{
    public class UnitProduction
    {



        public int Id { get; set; }

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
