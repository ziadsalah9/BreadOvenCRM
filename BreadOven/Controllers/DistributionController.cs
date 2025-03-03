using BreadOven.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BreadOven.Controllers
{

    public class DistributionController : BaseController
    {

        private readonly StoreContext _context;
        public DistributionController(StoreContext context)
        {

            _context = context;
        }


        [HttpPost("AddDistribution")]
        public async Task<ActionResult> AddDistribution( int id)
        {

            var result = _context.items.FirstOrDefault(x => x.Id == id);
            var SumofOperattingsHours = _context.items.Sum(p => p.OperatingHours);
            var fixedsalary = _context.typeOfCosts.FirstOrDefault(p => p.Name == "الاجور الثابتة").Cost;
            var variablesalary = _context.typeOfCosts.FirstOrDefault(p => p.Name == "الاجور المتغيرة").Cost;
            var Percentagee = result.OperatingHours * (decimal)Math.Pow(SumofOperattingsHours, -1);
            Distrubutionfromitem newdistribution = new()
            {

                Percentage = result.OperatingHours *(decimal) Math.Pow( SumofOperattingsHours,-1),

                FixedSalary = fixedsalary*Percentagee,
                VariableSalary = variablesalary*Percentagee,

                //FixedSalary = fixedsalary / (result.OperatingHours / SumofOperattingsHours),
                //VariableSalary = variablesalary / (result.OperatingHours / SumofOperattingsHours),
                //TotalOperatingSalary = (fixedsalary + variablesalary) / (result.OperatingHours / SumofOperattingsHours),
                TotalOperatingSalary = (fixedsalary* Percentagee) + (variablesalary*Percentagee),
                ItemId = id



            };

            await _context.Distrubutionfromitems.AddAsync(newdistribution);
            _context.SaveChanges();
            return Ok(new Response<Distrubutionfromitem>() { Value = newdistribution, Message = "distribution added successfully!" });


        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _context.Distrubutionfromitems.ToListAsync());

        }
    }
}

