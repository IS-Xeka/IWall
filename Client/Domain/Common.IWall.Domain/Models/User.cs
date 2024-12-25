namespace Common.IWall.Domain.Models;

public class User: Entity<int>
{
    public Guid UserExternalId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public bool IsActived { get; set; } = false;
}
