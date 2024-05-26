using MudBlazor;

namespace WebApp.Application.Common.Providers.Components;

public interface IMudTextFieldProvider
{
    InputType PasswordInputType { get; set; }
    string PasswordInputIcon { get; set; }
    bool ShowPassword { get; set; }
    Task PasswordEye_click();
}

public class MudTextFieldProvider : IMudTextFieldProvider
{
    public InputType PasswordInputType { get; set; } = InputType.Password;
    public string PasswordInputIcon { get; set; } = Icons.Material.Filled.VisibilityOff;
    public bool ShowPassword { get; set; } = false;
    public Task PasswordEye_click()
    {
        if (ShowPassword)
        {
            ShowPassword = false;
            PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
            PasswordInputType = InputType.Password;
        }
        else
        {
            ShowPassword = true;
            PasswordInputIcon = Icons.Material.Filled.Visibility;
            PasswordInputType = InputType.Text;
        }

        return Task.CompletedTask;
    }
}
