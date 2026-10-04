namespace SaqerAccountingSystem.Domain.Entities;

public class PurchaseInvoice : BaseEntity
{
    public string InvoiceNumber { get; set; } = string.Empty;
    public DateTime InvoiceDate { get; set; } = DateTime.UtcNow;
    public int SupplierId { get; set; }
    public Supplier? Supplier { get; set; }
    public decimal Discount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal NetAmount { get; set; }
    public bool IsPaid { get; set; }
    public string Status { get; set; } = "Draft";
    public List<PurchaseInvoiceLine> Lines { get; set; } = new();
}
