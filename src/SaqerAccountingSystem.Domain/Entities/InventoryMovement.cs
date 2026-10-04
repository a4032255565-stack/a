namespace SaqerAccountingSystem.Domain.Entities;

public class InventoryMovement : BaseEntity
{
    public int ItemId { get; set; }
    public Item? Item { get; set; }
    public int BranchId { get; set; }
    public Branch? Branch { get; set; }
    public int Quantity { get; set; }
    public string MovementType { get; set; } = "In"; // In, Out, Adjustment
    public string Reason { get; set; } = string.Empty;
    public DateTime MovementDate { get; set; } = DateTime.UtcNow;
}
