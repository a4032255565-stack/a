using SaqerAccountingSystem.Domain.Entities;

namespace SaqerAccountingSystem.Application.Services;

public class CompanyService : ICompanyService
{
    private readonly List<Company> _companies = new();

    public Task<IEnumerable<Company>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<Company>>(_companies);
    }

    public Task<Company?> GetByIdAsync(int id)
    {
        return Task.FromResult(_companies.FirstOrDefault(x => x.Id == id));
    }

    public Task<Company> CreateAsync(Company company)
    {
        company.Id = _companies.Count == 0 ? 1 : _companies.Max(x => x.Id) + 1;
        _companies.Add(company);
        return Task.FromResult(company);
    }

    public Task UpdateAsync(Company company)
    {
        var existing = _companies.FirstOrDefault(x => x.Id == company.Id);
        if (existing is null)
        {
            throw new KeyNotFoundException($"Company with Id {company.Id} was not found.");
        }

        existing.Name = company.Name;
        existing.DisplayName = company.DisplayName;
        existing.Phone = company.Phone;
        existing.Email = company.Email;
        existing.TaxNumber = company.TaxNumber;
        existing.Address = company.Address;
        existing.Currency = company.Currency;
        existing.LogoUrl = company.LogoUrl;
        existing.UpdatedAt = DateTime.UtcNow;

        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        var company = _companies.FirstOrDefault(x => x.Id == id);
        if (company is not null)
        {
            _companies.Remove(company);
        }

        return Task.CompletedTask;
    }
}
