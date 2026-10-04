namespace SaqerAccountingSystem.Domain.Entities;

public class TransactionJournal : BaseEntity
{
    public string TransactionNumber { get; set; } = string.Empty;
    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
    public string Description { get; set; } = string.Empty;
    public string TransactionType { get; set; } = "Manual";
    public int CompanyId { get; set; }
    public Company? Company { get; set; }
    public decimal TotalDebit { get; set; }
    public decimal TotalCredit { get; set; }
    public bool IsApproved { get; set; }
    public List<TransactionJournalLine> Lines { get; set; } = new();
}
