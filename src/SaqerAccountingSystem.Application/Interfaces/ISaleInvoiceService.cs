using SaqerAccountingSystem.Domain.Entities;

namespace SaqerAccountingSystem.Application.Interfaces;

public interface ISaleInvoiceService
{
    Task<IEnumerable<SaleInvoice>> GetAllAsync();
    Task<SaleInvoice?> GetByIdAsync(int id);
    Task<SaleInvoice> CreateAsync(SaleInvoice invoice);
    Task UpdateAsync(SaleInvoice invoice);
    Task DeleteAsync(int id);
}
