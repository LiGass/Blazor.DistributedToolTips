using DistributedToolTips.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace DistributedToolTips
{
	public class ToolTipElementComponentBase : ComponentBase
    {
        [Inject] private IJSRuntime JS { get; set; }
        [Inject] protected IToolTipState StateContainer { get; set; }
        [Inject] protected NavigationManager NavManager { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public RenderFragment Helper { get; set; } = default;
        [Parameter] public string HelperAsString { get; set; } = string.Empty;
        [Parameter] public string CustomCssClass { get; set; } = string.Empty;
        [Parameter] public string CustomHelperCssClass { get; set; } = string.Empty;
        protected ToolTipElementModel thisElement;
        protected ElementReference refThis { get; set; }
        protected string CssClass => $"{thisElement.GetCssClass()} {CustomCssClass}";
        protected string HelperCssClass => $"ToolTip-Helper {CustomCssClass}";
        protected override void OnInitialized()
        {
            StateContainer.OnChange += StateHasChanged;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender){
            if(firstRender){
                await JS.InvokeVoidAsync("jsToolTips.makeHelperPositionResponsive", refThis);
			}
		}

    }
}
