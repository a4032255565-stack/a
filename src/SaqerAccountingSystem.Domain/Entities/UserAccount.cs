namespace SaqerAccountingSystem.Domain.Entities;

public class Branch : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public int CompanyId { get; set; }
    public Company? Company { get; set; }
}
