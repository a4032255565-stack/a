using SaqerAccountingSystem.Application.Interfaces;
using SaqerAccountingSystem.Domain.Entities;

namespace SaqerAccountingSystem.Application.Services;

public class AccountingService : IAccountingService
{
    private readonly List<JournalEntry> _entries = new();

    public Task<decimal> GetBalanceAsync(int accountId)
    {
        var balance = _entries
            .SelectMany(e => e.Lines)
            .Where(line => line.AccountId == accountId)
            .Sum(line => line.Debit - line.Credit);

        return Task.FromResult(balance);
    }

    public Task<JournalEntry> CreateJournalEntryAsync(JournalEntry entry)
    {
        var totalDebit = entry.Lines.Sum(x => x.Debit);
        var totalCredit = entry.Lines.Sum(x => x.Credit);

        if (Math.Abs(totalDebit - totalCredit) > 0.01m)
        {
            throw new InvalidOperationException("Journal entry must be balanced.");
        }

        entry.Id = _entries.Count == 0 ? 1 : _entries.Max(x => x.Id) + 1;
        entry.CreatedAt = DateTime.UtcNow;
        _entries.Add(entry);

        return Task.FromResult(entry);
    }

    public Task<IEnumerable<JournalEntry>> GetEntriesAsync()
    {
        return Task.FromResult<IEnumerable<JournalEntry>>(_entries);
    }
}
