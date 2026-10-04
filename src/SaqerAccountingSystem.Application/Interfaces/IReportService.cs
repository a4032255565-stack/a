using SaqerAccountingSystem.Domain.Entities;

namespace SaqerAccountingSystem.Application.Interfaces;

public interface IInventoryService
{
    Task<IEnumerable<InventoryMovement>> GetAllAsync();
    Task<IEnumerable<InventoryMovement>> GetByItemAsync(int itemId);
    Task<InventoryMovement> AddAsync(InventoryMovement movement);
    Task<int> GetCurrentStockAsync(int itemId, int branchId);
}
