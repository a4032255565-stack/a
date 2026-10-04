namespace SaqerAccountingSystem.Domain.Entities;

public class SaleInvoiceLine : BaseEntity
{
    public int SaleInvoiceId { get; set; }
    public SaleInvoice? SaleInvoice { get; set; }
    public int ItemId { get; set; }
    public Item? Item { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Total { get; set; }
    public string Description { get; set; } = string.Empty;
}
