using Source.EF.Enums;

namespace Source.Server.Application.Handlers.UserProfiles.Create;

public class CreateUserProfilesRequest
{
    public string? Code { get; set; }
    public string Name { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string PhoneIDD { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public byte[]? Photo { get; set; }
    public decimal Height { get; set; }
    public float Weight { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public UserTypeEnum UserType { get; set; } = UserTypeEnum.Administrator;
    public string Password { get; set; } = string.Empty;
    public string SecurityCode { get; set; } = string.Empty;
}
