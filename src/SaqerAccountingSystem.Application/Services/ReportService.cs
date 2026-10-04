using SaqerAccountingSystem.Application.Interfaces;
using SaqerAccountingSystem.Domain.Entities;

namespace SaqerAccountingSystem.Application.Services;

public class InventoryService : IInventoryService
{
    private readonly List<InventoryMovement> _movements = new();
    private readonly List<Item> _items = new();

    public Task<IEnumerable<InventoryMovement>> GetAllAsync()
        => Task.FromResult<IEnumerable<InventoryMovement>>(_movements.OrderByDescending(x => x.MovementDate));

    public Task<IEnumerable<InventoryMovement>> GetByItemAsync(int itemId)
        => Task.FromResult<IEnumerable<InventoryMovement>>(
            _movements.Where(x => x.ItemId == itemId).OrderByDescending(x => x.MovementDate));

    public Task<InventoryMovement> AddAsync(InventoryMovement movement)
    {
        var item = _items.FirstOrDefault(x => x.Id == movement.ItemId);
        if (item is null)
            throw new KeyNotFoundException($"Item {movement.ItemId} not found.");

        movement.Id = _movements.Count == 0 ? 1 : _movements.Max(x => x.Id) + 1;
        movement.MovementDate = movement.MovementDate == default ? DateTime.UtcNow : movement.MovementDate;

        if (movement.MovementType.Equals("In", StringComparison.OrdinalIgnoreCase))
            item.StockQuantity += movement.Quantity;
        else if (movement.MovementType.Equals("Out", StringComparison.OrdinalIgnoreCase) ||
                 movement.MovementType.Equals("Adjustment", StringComparison.OrdinalIgnoreCase))
            item.StockQuantity -= movement.Quantity;

        _movements.Add(movement);
        return Task.FromResult(movement);
    }

    public Task<int> GetCurrentStockAsync(int itemId, int branchId)
    {
        var item = _items.FirstOrDefault(x => x.Id == itemId);
        if (item is null)
            return Task.FromResult(0);

        var movements = _movements.Where(x => x.ItemId == itemId && x.BranchId == branchId);
        var totalIn = movements.Where(x => x.MovementType.Equals("In", StringComparison.OrdinalIgnoreCase))
            .Sum(x => x.Quantity);
        var totalOut = movements.Where(x => x.MovementType.Equals("Out", StringComparison.OrdinalIgnoreCase) ||
            x.MovementType.Equals("Adjustment", StringComparison.OrdinalIgnoreCase))
            .Sum(x => x.Quantity);

        return Task.FromResult(item.StockQuantity + totalIn - totalOut);
    }

    public void SeedItems(IEnumerable<Item> items)
    {
        _items.Clear();
        _items.AddRange(items);
    }
}
