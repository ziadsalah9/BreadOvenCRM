using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreadOven.DTOs
{
    public class AddItemDto
    {

        [Required]
        [MinLength(3,ErrorMessage= "ادخل اسم اكثر من 3 حروف ")]
        public string Name { get; set; }

        [Required]
        public int EnergyReq { get; set; }

        [Required]
        public int OperatingHours { get; set; }

        [Required (ErrorMessage ="من فضلك ادخل خط الانتاج التابع له هذا الصنف")]
        public int factoryLinesId { get; set; }
    }
}

