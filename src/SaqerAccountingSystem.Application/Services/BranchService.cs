using SaqerAccountingSystem.Application.Interfaces;
using SaqerAccountingSystem.Domain.Entities;

namespace SaqerAccountingSystem.Application.Services;

public class BranchService : IBranchService
{
    private readonly List<Branch> _branches = new();

    public Task<IEnumerable<Branch>> GetAllAsync() => Task.FromResult<IEnumerable<Branch>>(_branches);

    public Task<Branch?> GetByIdAsync(int id) => Task.FromResult(_branches.FirstOrDefault(x => x.Id == id));

    public Task<Branch> CreateAsync(Branch branch)
    {
        branch.Id = _branches.Count == 0 ? 1 : _branches.Max(x => x.Id) + 1;
        _branches.Add(branch);
        return Task.FromResult(branch);
    }

    public Task UpdateAsync(Branch branch)
    {
        var existing = _branches.FirstOrDefault(x => x.Id == branch.Id);
        if (existing is null)
            throw new KeyNotFoundException($"Branch {branch.Id} not found.");

        existing.Name = branch.Name;
        existing.Address = branch.Address;
        existing.Phone = branch.Phone;
        existing.CompanyId = branch.CompanyId;
        existing.UpdatedAt = DateTime.UtcNow;

        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        var branch = _branches.FirstOrDefault(x => x.Id == id);
        if (branch is not null)
            _branches.Remove(branch);

        return Task.CompletedTask;
    }
}
