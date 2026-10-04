using SaqerAccountingSystem.Application.Interfaces;
using SaqerAccountingSystem.Domain.Entities;

namespace SaqerAccountingSystem.Application.Services;

public class SupplierService : ISupplierService
{
    private readonly List<Supplier> _suppliers = new();

    public Task<IEnumerable<Supplier>> GetAllAsync()
        => Task.FromResult<IEnumerable<Supplier>>(_suppliers);

    public Task<Supplier?> GetByIdAsync(int id)
        => Task.FromResult(_suppliers.FirstOrDefault(x => x.Id == id));

    public Task<Supplier> CreateAsync(Supplier supplier)
    {
        supplier.Id = _suppliers.Count == 0 ? 1 : _suppliers.Max(x => x.Id) + 1;
        _suppliers.Add(supplier);
        return Task.FromResult(supplier);
    }

    public Task UpdateAsync(Supplier supplier)
    {
        var existing = _suppliers.FirstOrDefault(x => x.Id == supplier.Id);
        if (existing is null)
            throw new KeyNotFoundException($"Supplier {supplier.Id} not found.");

        existing.Name = supplier.Name;
        existing.Phone = supplier.Phone;
        existing.Email = supplier.Email;
        existing.Address = supplier.Address;
        existing.TaxNumber = supplier.TaxNumber;
        existing.IsActive = supplier.IsActive;
        existing.UpdatedAt = DateTime.UtcNow;

        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        var supplier = _suppliers.FirstOrDefault(x => x.Id == id);
        if (supplier is not null)
            _suppliers.Remove(supplier);

        return Task.CompletedTask;
    }
}
