using System.Security.Claims;

namespace WebApp.Application.Common.Services.AuthenState;
public interface IAuthenticationService
{
    ClaimsPrincipal CurrentUser { get; set; }
    event Action<ClaimsPrincipal>? UserChanged;
}

public class AuthenticationService : IAuthenticationService
{
    public event Action<ClaimsPrincipal>? UserChanged;
    private ClaimsPrincipal? _currentUser;

    public ClaimsPrincipal CurrentUser
    {
        get { return _currentUser ?? new(); }
        set
        {
            _currentUser = value;

            if (UserChanged is not null)
            {
                UserChanged(_currentUser);
            }
        }
    }
}
