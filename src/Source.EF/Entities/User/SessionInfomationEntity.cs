
using Source.EF.Bases.Entities;

namespace Source.EF.Entities.User;

public class SessionInfomationEntity : IBaseEntity
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
    public byte[]? Timestamp { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool Active { get; set; }
    public int? UserId { get; set; }
    public virtual UserProfileEntity? UserProfile { get; set; }
}
