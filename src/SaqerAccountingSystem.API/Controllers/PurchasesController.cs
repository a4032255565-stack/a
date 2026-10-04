using Microsoft.AspNetCore.Mvc;
using SaqerAccountingSystem.Application.Interfaces;
using SaqerAccountingSystem.Domain.Entities;

namespace SaqerAccountingSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PurchasesController : ControllerBase
{
    private readonly IPurchaseInvoiceService _purchaseInvoiceService;

    public PurchasesController(IPurchaseInvoiceService purchaseInvoiceService)
    {
        _purchaseInvoiceService = purchaseInvoiceService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _purchaseInvoiceService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var invoice = await _purchaseInvoiceService.GetByIdAsync(id);
        return invoice is null ? NotFound() : Ok(invoice);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PurchaseInvoice invoice)
    {
        var created = await _purchaseInvoiceService.CreateAsync(invoice);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }
}
