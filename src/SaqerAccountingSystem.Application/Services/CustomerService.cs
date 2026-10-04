using SaqerAccountingSystem.Application.Interfaces;
using SaqerAccountingSystem.Domain.Entities;

namespace SaqerAccountingSystem.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly List<Customer> _customers = new();

    public Task<IEnumerable<Customer>> GetAllAsync()
        => Task.FromResult<IEnumerable<Customer>>(_customers);

    public Task<Customer?> GetByIdAsync(int id)
        => Task.FromResult(_customers.FirstOrDefault(x => x.Id == id));

    public Task<Customer> CreateAsync(Customer customer)
    {
        customer.Id = _customers.Count == 0 ? 1 : _customers.Max(x => x.Id) + 1;
        _customers.Add(customer);
        return Task.FromResult(customer);
    }

    public Task UpdateAsync(Customer customer)
    {
        var existing = _customers.FirstOrDefault(x => x.Id == customer.Id);
        if (existing is null)
            throw new KeyNotFoundException($"Customer {customer.Id} not found.");

        existing.Name = customer.Name;
        existing.Phone = customer.Phone;
        existing.Email = customer.Email;
        existing.Address = customer.Address;
        existing.TaxNumber = customer.TaxNumber;
        existing.IsActive = customer.IsActive;
        existing.UpdatedAt = DateTime.UtcNow;

        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        var customer = _customers.FirstOrDefault(x => x.Id == id);
        if (customer is not null)
            _customers.Remove(customer);

        return Task.CompletedTask;
    }
}
