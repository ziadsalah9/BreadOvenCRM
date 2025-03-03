using BreadOven.Models;
using System.ComponentModel.DataAnnotations;

namespace BreadOven.DTOs
{
    public class AddCost
    {
        public string Name { get; set; }

        public decimal Cost { get; set; }

        [Required]
        [Range(1,4 , ErrorMessage = "please enter number from  1  , 2 , 3 , 4  " +
            "  \n " +
      "1 -> اجور تشغيلية " +
      "2->  مواد خام " +
      "3->  تكاليف غير مباشرة ثابته " +
      "4-> تكاليف غير مباشرة متغيرة  ")]
        public int Type { get; set; }

        
    }
}
