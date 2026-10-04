namespace SaqerAccountingSystem.Domain.Entities;

public class Payment : BaseEntity
{
    public int InvoiceId { get; set; }
    public Invoice? Invoice { get; set; }
    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; } = "Cash";
    public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
    public string ReferenceNo { get; set; } = string.Empty;
}
