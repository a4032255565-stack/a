using SaqerAccountingSystem.Application.Interfaces;
using SaqerAccountingSystem.Domain.Entities;

namespace SaqerAccountingSystem.Application.Services;

public class ItemService : IItemService
{
    private readonly List<Item> _items = new();

    public Task<IEnumerable<Item>> GetAllAsync() => Task.FromResult<IEnumerable<Item>>(_items);

    public Task<Item?> GetByIdAsync(int id) => Task.FromResult(_items.FirstOrDefault(x => x.Id == id));

    public Task<Item> CreateAsync(Item item)
    {
        item.Id = _items.Count == 0 ? 1 : _items.Max(x => x.Id) + 1;
        _items.Add(item);
        return Task.FromResult(item);
    }

    public Task UpdateAsync(Item item)
    {
        var existing = _items.FirstOrDefault(x => x.Id == item.Id);
        if (existing is null)
            throw new KeyNotFoundException($"Item {item.Id} not found.");

        existing.Code = item.Code;
        existing.Name = item.Name;
        existing.Description = item.Description;
        existing.PurchasePrice = item.PurchasePrice;
        existing.SalePrice = item.SalePrice;
        existing.StockQuantity = item.StockQuantity;
        existing.CompanyId = item.CompanyId;
        existing.UpdatedAt = DateTime.UtcNow;

        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        var item = _items.FirstOrDefault(x => x.Id == id);
        if (item is not null)
            _items.Remove(item);

        return Task.CompletedTask;
    }
}
