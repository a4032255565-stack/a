using SaqerAccountingSystem.Application.Interfaces;
using SaqerAccountingSystem.Domain.Entities;

namespace SaqerAccountingSystem.Application.Services;

public class InvoiceService : IInvoiceService
{
    private readonly List<Invoice> _invoices = new();

    public Task<IEnumerable<Invoice>> GetAllAsync()
        => Task.FromResult<IEnumerable<Invoice>>(_invoices);

    public Task<IEnumerable<Invoice>> GetByTypeAsync(string invoiceType)
        => Task.FromResult<IEnumerable<Invoice>>(_invoices.Where(x => x.InvoiceType == invoiceType));

    public Task<Invoice?> GetByIdAsync(int id)
        => Task.FromResult(_invoices.FirstOrDefault(x => x.Id == id));

    public Task<Invoice> CreateAsync(Invoice invoice)
    {
        invoice.Id = _invoices.Count == 0 ? 1 : _invoices.Max(x => x.Id) + 1;
        invoice.InvoiceNumber = string.IsNullOrWhiteSpace(invoice.InvoiceNumber)
            ? $"INV-{invoice.Id:0000}"
            : invoice.InvoiceNumber;
        _invoices.Add(invoice);
        return Task.FromResult(invoice);
    }

    public Task UpdateAsync(Invoice invoice)
    {
        var existing = _invoices.FirstOrDefault(x => x.Id == invoice.Id);
        if (existing is null)
            throw new KeyNotFoundException($"Invoice {invoice.Id} not found.");

        existing.InvoiceNumber = invoice.InvoiceNumber;
        existing.InvoiceDate = invoice.InvoiceDate;
        existing.TotalAmount = invoice.TotalAmount;
        existing.TaxAmount = invoice.TaxAmount;
        existing.NetAmount = invoice.NetAmount;
        existing.InvoiceType = invoice.InvoiceType;
        existing.CustomerId = invoice.CustomerId;
        existing.SupplierId = invoice.SupplierId;
        existing.IsPaid = invoice.IsPaid;
        existing.Status = invoice.Status;
        existing.UpdatedAt = DateTime.UtcNow;

        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        var invoice = _invoices.FirstOrDefault(x => x.Id == id);
        if (invoice is not null)
            _invoices.Remove(invoice);

        return Task.CompletedTask;
    }
}
