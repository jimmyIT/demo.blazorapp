namespace Source.Server.Application.Common.Provider;

public interface IValidationProvider
{
    string EmailAddressRegex { get; }
    string PasswordStrength { get; }
    int MinLength { get; }
    int MaxLength { get; }
    int MinPasswordLength { get; }
    int MaxPasswordLength { get; }
}

public class ValidationProvider : IValidationProvider
{
    public string EmailAddressRegex => "\\w+([-!#$%&‘*'+–/=?^_{1}`.{|}~]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

    public string PasswordStrength => "^.*(?=.{8,12})(?=.*[a-z])(?=.*[A-Z])(?=.*[\\d]).*$";

    public int MinLength => 1;

    public int MaxLength => 255;

    public int MinPasswordLength => 8;

    public int MaxPasswordLength => 15;
}
