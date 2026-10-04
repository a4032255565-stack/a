using SaqerAccountingSystem.Domain.Entities;

namespace SaqerAccountingSystem.Application.Services;

public class AccountService : IAccountService
{
    private readonly List<Account> _accounts = new();

    public Task<IEnumerable<Account>> GetAllAsync()
        => Task.FromResult<IEnumerable<Account>>(_accounts);

    public Task<Account?> GetByIdAsync(int id)
        => Task.FromResult(_accounts.FirstOrDefault(x => x.Id == id));

    public Task<Account> CreateAsync(Account account)
    {
        account.Id = _accounts.Count == 0 ? 1 : _accounts.Max(x => x.Id) + 1;
        _accounts.Add(account);
        return Task.FromResult(account);
    }

    public Task UpdateAsync(Account account)
    {
        var existing = _accounts.FirstOrDefault(x => x.Id == account.Id);
        if (existing is null)
            throw new KeyNotFoundException($"Account {account.Id} not found.");

        existing.Code = account.Code;
        existing.Name = account.Name;
        existing.AccountType = account.AccountType;
        existing.ParentAccountId = account.ParentAccountId;
        existing.OpeningBalance = account.OpeningBalance;
        existing.IsActive = account.IsActive;
        existing.CompanyId = account.CompanyId;
        existing.UpdatedAt = DateTime.UtcNow;

        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        var account = _accounts.FirstOrDefault(x => x.Id == id);
        if (account is not null)
            _accounts.Remove(account);

        return Task.CompletedTask;
    }
}
