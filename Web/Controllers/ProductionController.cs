using Services.Models;
using Microsoft.AspNetCore.Mvc;
using Services;
using Web.Dtos;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductionController : ControllerBase
{
    private readonly ProductionService _productionService;

    public ProductionController(ProductionService productionService)
    {
        _productionService = productionService;
    }

    [HttpPost]
    [Route("productionplan")]
    public ActionResult<IEnumerable<PowerPlantProductionDto>> ProductionPlan(ProductionPlanRequestDto request)
    {
        try
        {
            var powerPlantProductions = _productionService.ComputeProductionPlan(
                request.Load,
                request.Powerplants.Select(powerPlant => powerPlant.MapTo(request.Fuels)).ToList());
            return Ok(powerPlantProductions.Select(PowerPlantProductionDto.MapFrom));
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}