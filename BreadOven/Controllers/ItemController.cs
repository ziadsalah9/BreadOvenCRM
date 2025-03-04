using BreadOven.core.IRepositories;
using BreadOven.core.Models;
using BreadOven.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BreadOven.Controllers
{

    public class ItemController : BaseController
    {



        private readonly IGenricRepository<Item> _ItemRepo;
        private readonly IGenricRepository<ProductionLineDepreciation> _ProductionLineDepreciationRepo;



        public ItemController(IGenricRepository<Item> ItemRepo, IGenricRepository<ProductionLineDepreciation> ProductionLineDepreciationRepo)
        {
            
            _ItemRepo = ItemRepo;
            _ProductionLineDepreciationRepo = ProductionLineDepreciationRepo;
        }
       

        [HttpPost("AddItem")]
        public async Task<ActionResult> AddItem(AddItemDto addItem)
        {


            //var res = _context.ProductionLineDepreciations.Sum(p => p.valueHour);

            var res = await _ProductionLineDepreciationRepo.SumAsync(p => p.valueHour);   


            Item newitem = new Item()
            {
                EnergyReq = addItem.EnergyReq,
                Name = addItem.Name,
                OperatingHours = addItem.OperatingHours,
                factoryLinesId = addItem.factoryLinesId,
                HourlyOperatingRate = addItem.OperatingHours * (decimal)Math.Pow(addItem.EnergyReq, -1),
                Totalvalueofhoursdeprication = res * (1 * addItem.OperatingHours * (decimal)Math.Pow(addItem.EnergyReq, -1))



            };
            

           await _ItemRepo.AddAsync(newitem);
            return Ok(new Response<Item>() { Value = newitem, Message = "item added successfully!" });




        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {


            return Ok(await _ItemRepo.GetAll());
        }

    }
}