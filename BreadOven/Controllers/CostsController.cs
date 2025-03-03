using BreadOven.DTOs;
using BreadOven.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BreadOven.Controllers
{
    public class CostsController : BaseController
    {


        private readonly StoreContext _context;
        public CostsController(StoreContext context)
        {

            _context = context;
        }


        [HttpPost("AddCost")]
        public async Task<ActionResult> Add(AddCost add)
        {


            Costs newcosts = new Costs()
            {
                Name = add.Name,
                Cost = add.Cost,
                Type = (int)add.Type
                
            };


            await _context.typeOfCosts.AddAsync(newcosts);
            _context.SaveChanges();

            return Ok (new Response<Costs>() { Value = newcosts, Message = "Cost added successfully!" });
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _context.typeOfCosts.ToListAsync());
        }




    }
}
