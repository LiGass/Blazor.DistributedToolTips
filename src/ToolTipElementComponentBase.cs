using ToolTips.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace ToolTips
{
	public class ToolTipElementComponentBase : ComponentBase, IDisposable
    {
        [Inject] private IJSRuntime JS { get; set; }
        [Inject] protected IToolTipService TooltipService { get; set; }
        [Parameter] public RenderFragment? InlineContent { get; set; } = null;
        [Parameter] public RenderFragment? ChildContent { get; set; }
        [Parameter] public RenderFragment? HelperContent { get; set; } = null;
        [Parameter] public string HelperText { get; set; } = string.Empty;
        [Parameter] public string CustomCssClass { get; set; } = string.Empty;
        [Parameter] public string CustomHelperCssClass { get; set; } = string.Empty;
        [Parameter] public bool? HelperAlwaysDisplayable { get; set; } = null;
        protected bool AlwaysVisible;
        [Parameter] public bool HighlightInlineContentWhenActive { get; set; } = true;
        protected ElementReference refThis { get; set; }
        protected string Visibility { get => (TooltipService.IsActive) ?"displayed":"hidden"; }
        protected string HelperCssClass { get; set; } = string.Empty;
        protected override void OnInitialized()
        {
            if(InlineContent != null) ChildContent= InlineContent;
            TooltipService.OnChange += StateHasChanged;
        }
        protected override async Task OnAfterRenderAsync(bool firstRender){
            if(firstRender){
                await JS.InvokeVoidAsync("jsToolTips.makeHelperPositionResponsive", refThis);
			}
		}
        public void Dispose()
        {
            TooltipService.OnChange -= StateHasChanged;
        }
    }
}
