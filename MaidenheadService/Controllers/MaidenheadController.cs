using System.Net;
using MaidenheadLib;
using MaidenheadService.Model;
using Microsoft.AspNetCore.Mvc;

namespace MaindenheadService.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class MaidenheadController: ControllerBase
{
    private readonly ILogger<MaidenheadController> _logger;
    
    public MaidenheadController(ILogger<MaidenheadController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet]
    [Route("bearing")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public IActionResult Bearing([FromQuery]string srcGrid, [FromQuery]string destGrid)
    {
        if (!string.IsNullOrEmpty(srcGrid) && !string.IsNullOrEmpty(destGrid))
        {
            var start = MaidenheadLocator.LocatorToLatLng(srcGrid);
            var end = MaidenheadLocator.LocatorToLatLng(destGrid);
        
            return Ok(Math.Round(MaidenheadLocator.Azimuth(start, end), 0, MidpointRounding.AwayFromZero));
        }

        return BadRequest("Missing source or destination grid");
    }
    
    [HttpGet]
    [Route("distance")]
    [ProducesResponseType(typeof(Distance), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public IActionResult Distance([FromQuery]string srcGrid, [FromQuery]string destGrid)
    {
        if (!string.IsNullOrEmpty(srcGrid) && !string.IsNullOrEmpty(destGrid))
        {
            var start = MaidenheadLocator.LocatorToLatLng(srcGrid);
            var end = MaidenheadLocator.LocatorToLatLng(destGrid);
            var distance = new Distance(MaidenheadLocator.Distance(start, end));
            return Ok(distance);
        }

        return BadRequest("Missing source or destination grid");
    }
}