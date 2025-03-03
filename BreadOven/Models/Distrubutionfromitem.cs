using System.ComponentModel.DataAnnotations.Schema;

namespace BreadOven.Models
{
    public class Distrubutionfromitem
    {

        public int Id { get; set; }

        public decimal Percentage { get; set; }

        public decimal FixedSalary { get; set; }
        public decimal VariableSalary { get; set; }

        public decimal TotalOperatingSalary  { get; set; }   //  = fiexdsalary + VariableSalary 

        [ForeignKey("Item")]

        public int ItemId { get; set; }
        public Item Item { get; set; }  

    }
}
