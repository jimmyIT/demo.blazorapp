using Microsoft.AspNetCore.Components;
using WebApp.Application.Processors.ApplicationParameters.GetAll;

namespace WebApp.Components.Layout;

public partial class BasicLayout
{
    [Inject] IGetApplicationConfigurationProcessor _getApplicationConfigurationProcessor { get; set; } = default!;
    protected override async Task OnInitializedAsync()
    {
        await _getApplicationConfigurationProcessor.DoActionAsync();
    }
}
