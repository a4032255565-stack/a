using SaqerAccountingSystem.Domain.Entities;

namespace SaqerAccountingSystem.Application.Interfaces;

public interface IPurchaseInvoiceService
{
    Task<IEnumerable<PurchaseInvoice>> GetAllAsync();
    Task<PurchaseInvoice?> GetByIdAsync(int id);
    Task<PurchaseInvoice> CreateAsync(PurchaseInvoice invoice);
    Task UpdateAsync(PurchaseInvoice invoice);
    Task DeleteAsync(int id);
}
