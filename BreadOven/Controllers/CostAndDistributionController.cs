using BreadOven.core.IRepositories;
using BreadOven.core.Models;
using BreadOven.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BreadOven.Controllers
{

    public class CostAndDistributionController : BaseController
    {

        private readonly IGenricRepository<CostsAndDistrubutionfromitem> _costsAndDistrubutionfromitemRepo;
        private readonly IGenricRepository<Item> _itemRepo;

        public CostAndDistributionController(IGenricRepository<CostsAndDistrubutionfromitem> costsAndDistrubutionfromitem, IGenricRepository<Item> itemRepo)
        {
            _costsAndDistrubutionfromitemRepo = costsAndDistrubutionfromitem;
            _itemRepo = itemRepo;

        }


        [HttpPost("AddDistribution")]
        public async Task<ActionResult> AddDistribution( int itemid , AddCost add)
        {


            if (itemid !=null)
            {
                var result = await _itemRepo.GetById(itemid);
              
                if (result != null )
                {

                    
                    var SumofOperattingsHours =(double) await _itemRepo.SumAsync(p => p.OperatingHours);
                    //var fixedsalary = _context.typeOfCosts.FirstOrDefault(p => p.Name == "الاجور الثابتة").Cost;
                    //var variablesalary = _context.typeOfCosts.FirstOrDefault(p => p.Name == "الاجور المتغيرة").Cost;
                    var Percentagee = result.OperatingHours * (decimal)Math.Pow(SumofOperattingsHours, -1);
                    CostsAndDistrubutionfromitem newdistribution = new()
                    {

                        Percentage = result.OperatingHours * (decimal)Math.Pow(SumofOperattingsHours, -1),

                        Cost = add.Cost,

                        DistCost = add.Cost * Percentagee,
                        Name = add.Name,
                        Type = add.Type,


                        //FixedSalary = fixedsalary / (result.OperatingHours / SumofOperattingsHours),
                        //VariableSalary = variablesalary / (result.OperatingHours / SumofOperattingsHours),
                        //TotalOperatingSalary = (fixedsalary + variablesalary) / (result.OperatingHours / SumofOperattingsHours),
                        //TotalOperatingSalary = (fixedsalary* Percentagee) + (variablesalary*Percentagee),
                        ItemId = itemid



                    };

                 await _costsAndDistrubutionfromitemRepo.AddAsync(newdistribution);
                    return Ok(new Response<CostsAndDistrubutionfromitem>() { Value = newdistribution, Message = "تم الاضافة بنجاح !" });
                }
                else
                {
                    return BadRequest(new Response<CostsAndDistrubutionfromitem>() { Message = "لا يوجد هذا العنصر فى الوقت الحالى" });


                }

            }
            else
            {
                return BadRequest(new Response<CostsAndDistrubutionfromitem>() {  Message = "! فشل الاضافة " });

            }

        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _costsAndDistrubutionfromitemRepo.GetAll());

        }
    }
}



