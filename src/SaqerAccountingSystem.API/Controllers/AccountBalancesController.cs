using Microsoft.AspNetCore.Mvc;
using SaqerAccountingSystem.Application.Interfaces;

namespace SaqerAccountingSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountBalancesController : ControllerBase
{
    private readonly IAccountBalanceService _accountBalanceService;

    public AccountBalancesController(IAccountBalanceService accountBalanceService)
    {
        _accountBalanceService = accountBalanceService;
    }

    [HttpGet("{accountId:int}")]
    public async Task<IActionResult> GetBalance(int accountId)
    {
        var balance = await _accountBalanceService.GetCurrentBalanceAsync(accountId);
        return Ok(new { accountId, balance });
    }
}
