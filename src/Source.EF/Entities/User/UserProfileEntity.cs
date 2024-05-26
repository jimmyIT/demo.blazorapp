using Source.EF.Bases.Entities;
using Source.EF.Enums;

namespace Source.EF.Entities.User;

public class UserProfileEntity : IBaseEntityDetails
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
    public string HashedSecurityCode { get; set; } = string.Empty;
    public string HashedPassword { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string PhoneIDD { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public byte[]? Timestamp { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? AmendedOn { get; set; }
    public byte[]? Photo { get; set; }
    public decimal Height { get; set; }
    public float Weight { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public UserTypeEnum Type { get; set; }
    public UserStatusEnum Status { get; set; }
    public string CreateBy { get; set; } = string.Empty;
    public string AmendedBy { get; set; } = string.Empty;

    public virtual ICollection<SessionInfomationEntity>? SessionInfomations { get; set; }
}
