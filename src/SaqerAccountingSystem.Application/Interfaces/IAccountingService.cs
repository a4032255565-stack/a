using SaqerAccountingSystem.Domain.Entities;

namespace SaqerAccountingSystem.Application.Interfaces;

public interface IAccountingService
{
    Task<decimal> GetBalanceAsync(int accountId);
    Task<JournalEntry> CreateJournalEntryAsync(JournalEntry entry);
    Task<IEnumerable<JournalEntry>> GetEntriesAsync();
}
