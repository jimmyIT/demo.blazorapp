
using Source.EF.Bases.Entities;

namespace Source.EF.Entities.User;

public class SessionInfomationEntity : IBaseEntityDetails
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public byte[]? Timestamp { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? AmendedOn { get; set; }
    public bool Active { get; set; }
    public string CreateBy { get; set; } = string.Empty;
    public string AmendedBy { get; set; } = string.Empty;

    public string? UserCode { get; set; }
    public virtual UserProfileEntity? UserProfile { get; set; }
}
