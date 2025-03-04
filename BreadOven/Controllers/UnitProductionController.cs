using BreadOven.core.IRepositories;
using BreadOven.core.Models;
using BreadOven.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BreadOven.Controllers
{

    public class UnitProductionController : ControllerBase
    {

        private readonly IGenricRepository<UnitProduction> _unitproductionRepo;
        private readonly IGenricRepository<Item> _itemsRepo;
        private readonly IGenricRepository<CostsAndDistrubutionfromitem> _CostsAndDistrubutionfromitemRepo;

        public UnitProductionController(IGenricRepository<UnitProduction> unitproductionRepo , IGenricRepository<Item>itemsRepo,
            IGenricRepository<CostsAndDistrubutionfromitem> CostsAndDistrubutionfromitemRepo)
        {
           _unitproductionRepo = unitproductionRepo;
            _itemsRepo = itemsRepo;
            _CostsAndDistrubutionfromitemRepo = CostsAndDistrubutionfromitemRepo;

        }


        [HttpPost("AddUnitProduction")]

        public async Task<ActionResult> AddUnitProductions(UnitProductionDto undto )
        {


            
            // here 

          


            //var sa3ateltash8el = _context.items.FirstOrDefault(p => p.Id == undto.idofitems);
            var sa3ateltash8el = await _itemsRepo.GetById(undto.idofitems);


            if (sa3ateltash8el != null)
            {
               // var costofunitproduction = _context.CostsAndDistrubutionfromitems.Where(c => c.Id == undto.idofCosts && c.ItemId==sa3ateltash8el.Id).FirstOrDefault();

                var costofunitproduction = await _CostsAndDistrubutionfromitemRepo.GetValue(p => p.Id == undto.idofCosts && p.ItemId == sa3ateltash8el.Id);

                // EXPRESSION<FUNC <CostsID,ItemID , T>> 
                if (costofunitproduction == null) return NotFound("غير موجود");

                //var dist = _context.CostsAndDistrubutionfromitems.FirstOrDefault(p => p.ItemId == undto.idofitems).Percentage;  // دايما هترجعلى قيمة عادى
                var dist = costofunitproduction.Percentage;  // دايما هترجعلى قيمة عادى


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
                        //ItemId = undto.idofitems,
                        costsAndDistributionId = undto.idofCosts,   // مبقتش محتاج السطر ده تقدر تشله عادى
                       

                      


                    };



                  await _unitproductionRepo.AddAsync(unitProduction);

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



/*
 
 

remove item fid 
add costanddis fid


            var sa3ateltash8el = _context.costsanddist.FirstOrDefault(p => p.Id == undto.idofcosts);

 
 
 */