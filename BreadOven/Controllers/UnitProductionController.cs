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

        public async Task<ActionResult> AddUnitProductions(int idofcosts,int idofitems , string unit , decimal Quantity , int unitno=1 )
        {



            var costofunitproduction = _context.typeOfCosts.Where(c => c.Id == idofcosts).FirstOrDefault();

            var sa3ateltash8el = _context.items.FirstOrDefault(p => p.Id == idofitems);
            var dist = _context.CostsAndDistrubutionfromitems.FirstOrDefault(p => p.ItemId == idofitems).Percentage;


            if (costofunitproduction == null )
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

                    unitType = unit,
                    OperatingHoursQuantity = Quantity,
                    UnitValue = costofunitproduction.Type == 1 ? costofunitproduction.Cost * Quantity : ((dist * costofunitproduction.Cost) / (sa3ateltash8el.OperatingHours))*Quantity,
                    unitNumber = unitno,
                    Price = costofunitproduction.Type == 1 ? costofunitproduction.Cost : (dist*costofunitproduction.Cost)/(sa3ateltash8el.OperatingHours),
                    ItemId = idofitems,
                    costsId = idofcosts,
                    
                    



                };



                _context.Add(unitProduction);
                await _context.SaveChangesAsync();

                return Ok(unitProduction);
            }

        }
    }
}
