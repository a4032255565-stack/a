namespace SaqerAccountingSystem.Domain.Entities;

public class TransactionJournalLine : BaseEntity
{
    public int TransactionJournalId { get; set; }
    public TransactionJournal? TransactionJournal { get; set; }
    public int AccountId { get; set; }
    public Account? Account { get; set; }
    public decimal Debit { get; set; }
    public decimal Credit { get; set; }
    public string Description { get; set; } = string.Empty;
}
