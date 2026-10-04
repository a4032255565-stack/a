using Microsoft.AspNetCore.Mvc;
using SaqerAccountingSystem.Application.Interfaces;
using SaqerAccountingSystem.Domain.Entities;

namespace SaqerAccountingSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private readonly IInventoryService _inventoryService;

    public InventoryController(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _inventoryService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("item/{itemId:int}")]
    public async Task<IActionResult> GetByItem(int itemId)
    {
        var result = await _inventoryService.GetByItemAsync(itemId);
        return Ok(result);
    }

    [HttpGet("stock/{itemId:int}/{branchId:int}")]
    public async Task<IActionResult> GetCurrentStock(int itemId, int branchId)
    {
        var stock = await _inventoryService.GetCurrentStockAsync(itemId, branchId);
        return Ok(new { itemId, branchId, stock });
    }

    [HttpPost]
    public async Task<IActionResult> AddMovement([FromBody] InventoryMovement movement)
    {
        var created = await _inventoryService.AddAsync(movement);
        return CreatedAtAction(nameof(GetByItem), new { itemId = created.ItemId }, created);
    }
}
