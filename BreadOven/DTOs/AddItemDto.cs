using BreadOven.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreadOven.DTOs
{
    public class AddItemDto
    {

        public string Name { get; set; }

        public int EnergyReq { get; set; }

        public int OperatingHours { get; set; }
        public int factoryLinesId { get; set; }
    }
}

