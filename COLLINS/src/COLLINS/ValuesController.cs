using Microsoft.AspNetCore.Mvc;

namespace COLLINS.Controllers;

[Route("api/[controller]")]
public class ValuesController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("test");
    }
}
