namespace SaqerAccountingSystem.Domain.Entities;

public class UserAccount : BaseEntity
{
    public string UserName { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Role { get; set; } = "User";
    public int CompanyId { get; set; }
    public Company? Company { get; set; }
}
