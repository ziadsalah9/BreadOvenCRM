using BreadOven.DTOs;
using BreadOven.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BreadOven.Controllers
{
  
    public class ItemController : BaseController
    {



        private readonly StoreContext _context;
        public ItemController(StoreContext context)
        {
            _context = context;
        }

        [HttpPost("AddItem")]
        public async Task <ActionResult> AddItem(AddItemDto addItem)
        {


            var res = _context.ProductionLineDepreciations.Sum(p => p.valueHour);


            Item newitem = new Item()
            {
                EnergyReq = addItem.EnergyReq,
                Name = addItem.Name,
                OperatingHours = addItem.OperatingHours,
                factoryLinesId = addItem.factoryLinesId,
                HourlyOperatingRate = addItem.OperatingHours *(decimal)Math.Pow(addItem.EnergyReq,-1),
                Totalvalueofhoursdeprication = res * (1 * addItem.OperatingHours*(decimal)Math.Pow(addItem.EnergyReq, -1))



            };

             await _context.items.AddAsync(newitem);
            _context.SaveChanges();
            return Ok(new Response<Item>() { Value = newitem , Message = "item added successfully!"});




        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {


            return Ok(await _context.items.ToListAsync());
        }


    }
}
