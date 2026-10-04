using Microsoft.AspNetCore.Mvc;
using SaqerAccountingSystem.Application.Interfaces;

namespace SaqerAccountingSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportsController : ControllerBase
{
    private readonly IReportService _reportService;

    public ReportsController(IReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpGet("dashboard")]
    public async Task<IActionResult> GetDashboard()
    {
        var summary = await _reportService.GetDashboardAsync();
        return Ok(summary);
    }
}
