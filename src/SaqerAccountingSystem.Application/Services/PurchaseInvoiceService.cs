using SaqerAccountingSystem.Application.Interfaces;
using SaqerAccountingSystem.Domain.Entities;

namespace SaqerAccountingSystem.Application.Services;

public class PurchaseInvoiceService : IPurchaseInvoiceService
{
    private readonly List<PurchaseInvoice> _invoices = new();

    public Task<IEnumerable<PurchaseInvoice>> GetAllAsync()
        => Task.FromResult<IEnumerable<PurchaseInvoice>>(_invoices);

    public Task<PurchaseInvoice?> GetByIdAsync(int id)
        => Task.FromResult(_invoices.FirstOrDefault(x => x.Id == id));

    public Task<PurchaseInvoice> CreateAsync(PurchaseInvoice invoice)
    {
        invoice.Id = _invoices.Count == 0 ? 1 : _invoices.Max(x => x.Id) + 1;
        invoice.InvoiceNumber = string.IsNullOrWhiteSpace(invoice.InvoiceNumber)
            ? $"PU-{invoice.Id:0000}"
            : invoice.InvoiceNumber;
        _invoices.Add(invoice);
        return Task.FromResult(invoice);
    }

    public Task UpdateAsync(PurchaseInvoice invoice)
    {
        var existing = _invoices.FirstOrDefault(x => x.Id == invoice.Id);
        if (existing is null)
            throw new KeyNotFoundException($"Purchase invoice {invoice.Id} not found.");

        existing.InvoiceNumber = invoice.InvoiceNumber;
        existing.InvoiceDate = invoice.InvoiceDate;
        existing.SupplierId = invoice.SupplierId;
        existing.Discount = invoice.Discount;
        existing.TaxAmount = invoice.TaxAmount;
        existing.TotalAmount = invoice.TotalAmount;
        existing.NetAmount = invoice.NetAmount;
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
