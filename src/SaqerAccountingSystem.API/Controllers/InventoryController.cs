using SaqerAccountingSystem.Application.Interfaces;
using SaqerAccountingSystem.Domain.Entities;

namespace SaqerAccountingSystem.Application.Services;

public class ReportService : IReportService
{
    private readonly List<Customer> _customers = new();
    private readonly List<Supplier> _suppliers = new();
    private readonly List<Invoice> _invoices = new();
    private readonly List<Item> _items = new();
    private readonly List<Branch> _branches = new();

    public Task<DashboardSummary> GetDashboardAsync()
    {
        var summary = new DashboardSummary
        {
            TotalCustomers = _customers.Count,
            TotalSuppliers = _suppliers.Count,
            TotalItems = _items.Count,
            TotalBranches = _branches.Count,
            TotalInvoices = _invoices.Count,
            TotalSales = _invoices
                .Where(i => i.InvoiceType.Equals("Sale", StringComparison.OrdinalIgnoreCase))
                .Sum(i => i.NetAmount),
            TotalPurchases = _invoices
                .Where(i => i.InvoiceType.Equals("Purchase", StringComparison.OrdinalIgnoreCase))
                .Sum(i => i.NetAmount),
            NetBalance = _invoices
                .Where(i => i.InvoiceType.Equals("Sale", StringComparison.OrdinalIgnoreCase))
                .Sum(i => i.NetAmount) - _invoices
                .Where(i => i.InvoiceType.Equals("Purchase", StringComparison.OrdinalIgnoreCase))
                .Sum(i => i.NetAmount)
        };

        return Task.FromResult(summary);
    }

    public void Seed(IEnumerable<Customer> customers, IEnumerable<Supplier> suppliers, IEnumerable<Invoice> invoices,
        IEnumerable<Item> items, IEnumerable<Branch> branches)
    {
        _customers.Clear();
        _suppliers.Clear();
        _invoices.Clear();
        _items.Clear();
        _branches.Clear();

        _customers.AddRange(customers);
        _suppliers.AddRange(suppliers);
        _invoices.AddRange(invoices);
        _items.AddRange(items);
        _branches.AddRange(branches);
    }
}
