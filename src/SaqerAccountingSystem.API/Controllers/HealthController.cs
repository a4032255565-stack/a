using Microsoft.AspNetCore.Mvc;

namespace SaqerAccountingSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            application = "Saqer Accounting System",
            status = "Healthy",
            timestamp = DateTime.UtcNow
        });
    }
}
