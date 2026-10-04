using Microsoft.AspNetCore.Mvc;
using SaqerAccountingSystem.Application.Interfaces;
using SaqerAccountingSystem.Domain.Entities;

namespace SaqerAccountingSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionJournalsController : ControllerBase
{
    private readonly ITransactionJournalService _transactionJournalService;

    public TransactionJournalsController(ITransactionJournalService transactionJournalService)
    {
        _transactionJournalService = transactionJournalService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _transactionJournalService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var journal = await _transactionJournalService.GetByIdAsync(id);
        return journal is null ? NotFound() : Ok(journal);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TransactionJournal journal)
    {
        var created = await _transactionJournalService.CreateAsync(journal);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}/approve")]
    public async Task<IActionResult> Approve(int id)
    {
        await _transactionJournalService.ApproveAsync(id);
        return Ok(new { message = "Transaction approved successfully." });
    }
}
