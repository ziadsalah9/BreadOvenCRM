using System.ComponentModel.DataAnnotations;

namespace BreadOven.Models
{
    public class Costs
    {

            
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Cost { get; set; }

        public int Type { get; set; }

    }
}
