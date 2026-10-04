using SaqerAccountingSystem.Domain.Entities;

namespace SaqerAccountingSystem.Application.Interfaces;

public interface IBranchService
{
    Task<IEnumerable<Branch>> GetAllAsync();
    Task<Branch?> GetByIdAsync(int id);
    Task<Branch> CreateAsync(Branch branch);
    Task UpdateAsync(Branch branch);
    Task DeleteAsync(int id);
}
