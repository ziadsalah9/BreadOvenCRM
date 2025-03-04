using BreadOven.core.IRepositories;
using BreadOven.core.Models;
using BreadOven.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace BreadOven.Controllers
{
    
    public class FactoryLinesController : BaseController
    {

        private readonly IGenricRepository<FactoryLines> _FactoryLineRepo;
        private readonly IHubContext<NotificationHub> hubContext; 

        public FactoryLinesController(IGenricRepository<FactoryLines> FactoryLineRepo, IHubContext<NotificationHub> hubContext)
        {
            _FactoryLineRepo = FactoryLineRepo;
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


                await _FactoryLineRepo.AddAsync(newfactory);

              //  await      _context.FactoryLines.AddAsync(newfactory);
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
            return Ok(await _FactoryLineRepo.GetAll());
        }


        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody] UpdateDto dto)
        {
            var old = await _FactoryLineRepo.GetById(dto.Id);

            if (old == null)
            {
                return NotFound(new { Message = "FactoryLine not found." });
            }

            old.Name = dto.newName;

            _FactoryLineRepo.Edit(old);


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
