using System.ComponentModel.DataAnnotations.Schema;

namespace BreadOven.Models
{
    public class CostsAndDistrubutionfromitem
    {

        public int Id { get; set; }



        public string Name { get; set; }

        public decimal Cost { get; set; }

        public int Type { get; set; }

        public decimal Percentage { get; set; }

        public decimal DistCost { get; set; }



        //public decimal TotalOperatingSalary  { get; set; }   //  = fiexdsalary + VariableSalary 

        [ForeignKey("Item")]

        public int ItemId { get; set; }
        public Item Item { get; set; }



      
    }
}
