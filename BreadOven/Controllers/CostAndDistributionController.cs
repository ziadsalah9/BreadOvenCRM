using BreadOven.DTOs;
using BreadOven.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BreadOven.Controllers
{

    public class CostAndDistributionController : BaseController
    {

        private readonly StoreContext _context;
        public CostAndDistributionController(StoreContext context)
        {

            _context = context;
        }


        [HttpPost("AddDistribution")]
        public async Task<ActionResult> AddDistribution( int itemid , AddCost add)
        {

            var result = _context.items.FirstOrDefault(x => x.Id == itemid);
            var SumofOperattingsHours = _context.items.Sum(p => p.OperatingHours);
            //var fixedsalary = _context.typeOfCosts.FirstOrDefault(p => p.Name == "الاجور الثابتة").Cost;
            //var variablesalary = _context.typeOfCosts.FirstOrDefault(p => p.Name == "الاجور المتغيرة").Cost;
            var Percentagee = result.OperatingHours * (decimal)Math.Pow(SumofOperattingsHours, -1);
            CostsAndDistrubutionfromitem newdistribution = new()
            {

                Percentage = result.OperatingHours *(decimal) Math.Pow( SumofOperattingsHours,-1),

                Cost =add.Cost,

                DistCost = add.Cost*Percentagee,
                Name = add.Name,
                Type = add.Type,
                

                //FixedSalary = fixedsalary / (result.OperatingHours / SumofOperattingsHours),
                //VariableSalary = variablesalary / (result.OperatingHours / SumofOperattingsHours),
                //TotalOperatingSalary = (fixedsalary + variablesalary) / (result.OperatingHours / SumofOperattingsHours),
                //TotalOperatingSalary = (fixedsalary* Percentagee) + (variablesalary*Percentagee),
                ItemId = itemid



            };

            await _context.CostsAndDistrubutionfromitems.AddAsync(newdistribution);
            _context.SaveChanges();
            return Ok(new Response<CostsAndDistrubutionfromitem>() { Value = newdistribution, Message = "distribution added successfully!" });


        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _context.CostsAndDistrubutionfromitems.ToListAsync());

        }
    }
}

