namespace SaqerAccountingSystem.Domain.Entities;

public class SaleInvoice : BaseEntity
{
    public string InvoiceNumber { get; set; } = string.Empty;
    public DateTime InvoiceDate { get; set; } = DateTime.UtcNow;
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public decimal Discount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal NetAmount { get; set; }
    public bool IsPaid { get; set; }
    public string Status { get; set; } = "Draft";
    public List<SaleInvoiceLine> Lines { get; set; } = new();
}
