using SaqerAccountingSystem.Application.Interfaces;
using SaqerAccountingSystem.Domain.Entities;

namespace SaqerAccountingSystem.Application.Services;

public class TransactionJournalService : ITransactionJournalService
{
    private readonly List<TransactionJournal> _journals = new();

    public Task<IEnumerable<TransactionJournal>> GetAllAsync()
        => Task.FromResult<IEnumerable<TransactionJournal>>(_journals);

    public Task<TransactionJournal?> GetByIdAsync(int id)
        => Task.FromResult(_journals.FirstOrDefault(x => x.Id == id));

    public Task<TransactionJournal> CreateAsync(TransactionJournal journal)
    {
        if (Math.Abs(journal.TotalDebit - journal.TotalCredit) > 0.01m)
            throw new InvalidOperationException("Transaction must be balanced (Debit = Credit).");

        journal.Id = _journals.Count == 0 ? 1 : _journals.Max(x => x.Id) + 1;
        journal.TransactionNumber = string.IsNullOrWhiteSpace(journal.TransactionNumber)
            ? $"TRX-{journal.Id:0000}"
            : journal.TransactionNumber;
        _journals.Add(journal);
        return Task.FromResult(journal);
    }

    public Task UpdateAsync(TransactionJournal journal)
    {
        var existing = _journals.FirstOrDefault(x => x.Id == journal.Id);
        if (existing is null)
            throw new KeyNotFoundException($"Transaction journal {journal.Id} not found.");

        if (existing.IsApproved)
            throw new InvalidOperationException("Cannot update an approved transaction.");

        existing.Description = journal.Description;
        existing.TransactionDate = journal.TransactionDate;
        existing.TotalDebit = journal.TotalDebit;
        existing.TotalCredit = journal.TotalCredit;
        existing.UpdatedAt = DateTime.UtcNow;

        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        var journal = _journals.FirstOrDefault(x => x.Id == id);
        if (journal is not null && !journal.IsApproved)
            _journals.Remove(journal);

        return Task.CompletedTask;
    }

    public Task ApproveAsync(int id)
    {
        var journal = _journals.FirstOrDefault(x => x.Id == id);
        if (journal is null)
            throw new KeyNotFoundException($"Transaction journal {id} not found.");

        journal.IsApproved = true;
        journal.UpdatedAt = DateTime.UtcNow;
        return Task.CompletedTask;
    }
}
