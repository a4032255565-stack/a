using Microsoft.AspNetCore.Mvc;
using SaqerAccountingSystem.Application.Interfaces;

namespace SaqerAccountingSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FinancialReportsController : ControllerBase
{
    private readonly IFinancialReportService _financialReportService;

    public FinancialReportsController(IFinancialReportService financialReportService)
    {
        _financialReportService = financialReportService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _financialReportService.GetAllAsync();
        return Ok(result);
    }

    [HttpPost("income-statement")]
    public async Task<IActionResult> GenerateIncomeStatement([FromQuery] int companyId, [FromQuery] DateTime fromDate, [FromQuery] DateTime toDate)
    {
        var report = await _financialReportService.GenerateIncomeStatementAsync(companyId, fromDate, toDate);
        return Ok(report);
    }

    [HttpPost("balance-sheet")]
    public async Task<IActionResult> GenerateBalanceSheet([FromQuery] int companyId, [FromQuery] DateTime asOfDate)
    {
        var report = await _financialReportService.GenerateBalanceSheetAsync(companyId, asOfDate);
        return Ok(report);
    }
}
