using System.ComponentModel.DataAnnotations;

namespace BreadOven.DTOs
{
    public class UnitProductionDto
    {





            [Required(ErrorMessage = "من فضلك ادخل العنصر")]


            public int idofCosts { get; set; }

            [Required(ErrorMessage ="من فضلك ادخل العنصر")]
            public int idofitems { get; set; }
            [Required]
       
            public string unit { get; set; }
            [Required (ErrorMessage = "من فضلك ادخل الكمية ")]
            public decimal Quantity { get; set; }
           
    }
}
