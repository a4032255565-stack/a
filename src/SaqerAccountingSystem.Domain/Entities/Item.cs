namespace SaqerAccountingSystem.Domain.Entities;

public class Item : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal PurchasePrice { get; set; }
    public decimal SalePrice { get; set; }
    public int StockQuantity { get; set; }
    public int CompanyId { get; set; }
    public Company? Company { get; set; }
}
