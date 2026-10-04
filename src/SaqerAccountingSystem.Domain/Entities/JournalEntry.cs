namespace SaqerAccountingSystem.Domain.Entities;

public class JournalEntry : BaseEntity
{
    public string ReferenceNo { get; set; } = string.Empty;
    public DateTime EntryDate { get; set; } = DateTime.UtcNow;
    public string Description { get; set; } = string.Empty;
    public string EntryType { get; set; } = string.Empty; // Voucher, Invoice, Adjustment
    public int CompanyId { get; set; }
    public Company? Company { get; set; }
    public List<JournalEntryLine> Lines { get; set; } = new();
}
