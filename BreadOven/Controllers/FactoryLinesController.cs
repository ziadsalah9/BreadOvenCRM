using BreadOven.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace BreadOven.Controllers
{
    
    public class FactoryLinesController : BaseController
    {

        private readonly StoreContext _context;

        public FactoryLinesController(StoreContext _context)
        {
            this._context = _context;
        }

        [HttpPost("AddFactory")]
        public async Task<ActionResult> AddFactory([FromBody] string name)
        {

            if (name.Length > 3 && name is not null)
            {
                FactoryLines newfactory = new FactoryLines()
                {
                    Name = name,
                };


                _context.FactoryLines.Add(newfactory);
                _context.SaveChanges();
                return Ok(new Response<FactoryLines>() { Value = newfactory, Message = "Factory added successfully!" });
            }
            else
            {
                return BadRequest(new Response<FactoryLines>() { Message = "أدخل اسم اكثر من 3 حروف" });
            }

        }

        [HttpGet("getall")]
        [ResponseCache(Duration =60,Location =ResponseCacheLocation.Client)]

        public async Task<ActionResult> GetAll()
        {
            return Ok(await _context.FactoryLines.ToListAsync());
        }



    }
}
