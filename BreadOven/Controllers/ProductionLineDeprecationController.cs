using BreadOven.DTOs;
using BreadOven.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BreadOven.Controllers
{
  
    public class ProductionLineDeprecationController : BaseController
    {
        private readonly StoreContext _context;

        public ProductionLineDeprecationController(StoreContext context)
        {
            _context = context;

        }

        [HttpPost("AddProductionLineDep")]
        public async Task< ActionResult> AddProductionLineDep(AddProductionLineDepDTO prod)
        {

            ProductionLineDepreciation newprod = new()
            {
                Name = prod.Name,
                ProductionAgeYear = prod.ProductionAgeYear,
                OriginalValue = prod.OriginalValue,
                ValuePercentage = $"{100 / (prod.ProductionAgeYear)}%",
                valueYear = prod.OriginalValue * ((decimal)Math.Pow(prod.ProductionAgeYear, -1)),
                valueMonth = prod.OriginalValue * ((decimal)Math.Pow(prod.ProductionAgeYear * 12, -1)),
                valueDay = prod.OriginalValue * ((decimal)Math.Pow(prod.ProductionAgeYear * 365, -1)),
                valueHour = prod.OriginalValue * ((decimal)Math.Pow(prod.ProductionAgeYear * 8760, -1))
            };


            await _context.ProductionLineDepreciations.AddAsync(newprod);
            _context.SaveChanges();

            return Ok(new Response<ProductionLineDepreciation>() { Value = newprod,Message = "Add Successfully!"});

        }

        [HttpGet("getall")]
        public async Task <ActionResult> GetAll()
        {

            return Ok( await _context.ProductionLineDepreciations.ToListAsync());
        }


        
        
        

    }
}
