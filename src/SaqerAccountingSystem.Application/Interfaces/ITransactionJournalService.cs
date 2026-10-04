using SaqerAccountingSystem.Domain.Entities;

namespace SaqerAccountingSystem.Application.Interfaces;

public interface ITransactionJournalService
{
    Task<IEnumerable<TransactionJournal>> GetAllAsync();
    Task<TransactionJournal?> GetByIdAsync(int id);
    Task<TransactionJournal> CreateAsync(TransactionJournal journal);
    Task UpdateAsync(TransactionJournal journal);
    Task DeleteAsync(int id);
    Task ApproveAsync(int id);
}
