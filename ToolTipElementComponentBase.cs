using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace DistributedToolTips
{
    public class ToolTipElementComponentBase : ComponentBase
    {
        [Inject] protected IToolTipState StateContainer { get; set; }
        [Inject] protected NavigationManager NavManager { get; set; }
        [Parameter] public string HtmlId { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public RenderFragment Helper { get; set; } = default;
        [Parameter] public string HelperAsString { get; set; } = string.Empty;
        [Parameter] public string CustomCssClass { get; set; } = string.Empty;
        [Parameter] public string CustomHelperCssClass { get; set; } = string.Empty;
        protected ToolTipElementModel thisElement;
        protected string CssClass => $"{thisElement.GetCssClass()} {CustomCssClass}";
        protected string HelperCssClass => $"ToolTip-Helper {CustomCssClass}";
        protected override async Task OnInitializedAsync()
        {
            StateContainer.OnChange += StateHasChanged;
        }

    }
}
