using Microsoft.AspNetCore.Mvc;
using SaqerAccountingSystem.Application.Interfaces;
using SaqerAccountingSystem.Domain.Entities;

namespace SaqerAccountingSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalesController : ControllerBase
{
    private readonly ISaleInvoiceService _saleInvoiceService;

    public SalesController(ISaleInvoiceService saleInvoiceService)
    {
        _saleInvoiceService = saleInvoiceService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _saleInvoiceService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var invoice = await _saleInvoiceService.GetByIdAsync(id);
        return invoice is null ? NotFound() : Ok(invoice);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SaleInvoice invoice)
    {
        var created = await _saleInvoiceService.CreateAsync(invoice);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }
}
