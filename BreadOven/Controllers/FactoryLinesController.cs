using BreadOven.Hubs;
using BreadOven.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace BreadOven.Controllers
{
    
    public class FactoryLinesController : BaseController
    {

        private readonly StoreContext _context;
        private readonly IHubContext<NotificationHub> hubContext; 

        public FactoryLinesController(StoreContext _context, IHubContext<NotificationHub> hubContext)
        {
            this._context = _context;
            this.hubContext = hubContext;
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


        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody] UpdateDto dto)
        {
            var old = await _context.FactoryLines.FindAsync(dto.Id);

            if (old == null)
            {
                return NotFound(new { Message = "FactoryLine not found." });
            }

            old.Name = dto.newName;

            await _context.SaveChangesAsync();

            string message = $"FactoryLine updated to: {dto.newName}.";

            await hubContext.Clients.All.SendAsync("ReceiveNotification", message);

            
            return Ok(new { Message = "FactoryLine updated and notification sent." });
        }


    }

    public class UpdateDto()
    {
        public int Id { get; set; }
        public string newName { get; set; }
    }

}
