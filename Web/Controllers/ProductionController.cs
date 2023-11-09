using Microsoft.AspNetCore.Mvc;
using Services;

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
    public IActionResult ProductionPlan()
    {
        return Ok();
    }
}