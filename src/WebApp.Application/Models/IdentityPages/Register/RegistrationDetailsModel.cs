namespace WebApp.Application.Models.IdentityPages.Register;

public class RegistrationDetailsModel
{
    public string EmailAddress { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string ConfirmPassword { get; set; } = string.Empty;
    public string SecurityCode { get; set; } = string.Empty;
    public string ConfirmSecurityCode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string PhoneIDD { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; } = DateTime.Now;
    public decimal Height { get; set; }
    public decimal Weight { get; set; }
}
