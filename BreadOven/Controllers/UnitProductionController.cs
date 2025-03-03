using BreadOven.DTOs;
using BreadOven.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BreadOven.Controllers
{

    public class UnitProductionController : ControllerBase
    {

        private readonly StoreContext _context;

        public UnitProductionController(StoreContext context)
        {
            _context = context;

        }


        [HttpPost("AddUnitProduction" +
            "")]

        public async Task<ActionResult> AddUnitProductions(UnitProductionDto undto )
        {




            var sa3ateltash8el = _context.items.FirstOrDefault(p => p.Id == undto.idofitems);

            if (sa3ateltash8el != null)
            {
                var costofunitproduction = _context.CostsAndDistrubutionfromitems.Where(c => c.Id == sa3ateltash8el.Id).FirstOrDefault();

                var dist = _context.CostsAndDistrubutionfromitems.FirstOrDefault(p => p.ItemId == undto.idofitems).Percentage;  // دايما هترجعلى قيمة عادى


                if (costofunitproduction == null)
                {
                    return NotFound();
                }
                else
                {
                    var unitProduction = new UnitProduction
                    {

                        //  1 مواد خام
                        //  2 تشغيلية
                        // 3 مباشرة
                        // 4 غير مباشرة

                        unitType = undto.unit,
                        OperatingHoursQuantity = undto.Quantity,
                        UnitValue = costofunitproduction.Type == 1 ? costofunitproduction.Cost * undto.Quantity : ((dist * costofunitproduction.Cost) / (sa3ateltash8el.OperatingHours)) * undto.Quantity,
                        Price = costofunitproduction.Type == 1 ? costofunitproduction.Cost : (dist * costofunitproduction.Cost) / (sa3ateltash8el.OperatingHours),
                        ItemId = undto.idofitems,
                        //costsId = undto.idofitems,   // مبقتش محتاج السطر ده تقدر تشله عادى





                    };



                    _context.Add(unitProduction);
                    await _context.SaveChangesAsync();

                    return Ok(unitProduction);
                }

                

            }
            else
            {
                return BadRequest(new Response<UnitProduction>() { Message = " لا يوجد هذا الصنف فى الوقت الحالى" });
            }





        }
    }
}
