namespace SaqerAccountingSystem.Domain.Entities;

public class PurchaseInvoiceLine : BaseEntity
{
    public int PurchaseInvoiceId { get; set; }
    public PurchaseInvoice? PurchaseInvoice { get; set; }
    public int ItemId { get; set; }
    public Item? Item { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Total { get; set; }
    public string Description { get; set; } = string.Empty;
}
