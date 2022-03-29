using DistributedToolTips.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace DistributedToolTips
{
	public interface IToolTipService : IDisposable
	{
		event Action OnChange;
		void NotifyStateChanged();
		void ActivateToolTip();
		bool IsActive { get; }
	}
	public class ToolTipService : IToolTipService
	{
		private readonly NavigationManager _navigationManager;
		private readonly IJSRuntime _jsRuntime;

		//private readonly ToolTipsJsInterop jsModule;
		private bool _toolTipsActive = false;
		public bool IsActive { get => _toolTipsActive; }
		public event Action? OnChange;
		public void NotifyStateChanged() => OnChange?.Invoke();
		public ToolTipService(NavigationManager navigationManager, IJSRuntime jsRuntime) // WASM -> [, HttpClient client, IConfiguration config]
		{
			_navigationManager = navigationManager;
			_jsRuntime = jsRuntime;
			_navigationManager.LocationChanged += NewPage;
		}

		public void ActivateToolTip()
		{
			_toolTipsActive = !_toolTipsActive;
			NotifyStateChanged();
		}


		/// <summary>
		/// Ensures that all settings are reset when the user navigates to a new page
		/// </summary>
		/// <param name="sender">The Application NavigationManager</param>
		/// <param name="e"></param>
		protected void NewPage(object sender, LocationChangedEventArgs e)
		{
			_toolTipsActive = false;
			NotifyStateChanged();
		}

		public void Dispose()
		{
			_navigationManager.LocationChanged -= NewPage;
		}


	}
}
