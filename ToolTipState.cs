using DistributedToolTips.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace DistributedToolTips
{
	public interface IToolTipState : IAsyncDisposable
	{
		event Action OnChange;
		void NotifyStateChanged();
		void ActivateToolTip();
		int IncrementAnchorsCount();
		bool IsActive { get; }
		bool IsLastRegisteredElement(ToolTipElementModel element);
	}
	public class ToolTipState : IToolTipState
	{
		private readonly NavigationManager _navigationManager;
		private readonly IJSRuntime _jsRuntime;

		//private readonly ToolTipsJsInterop jsModule;
		private bool _toolTipsActive = false;
		private int anchorsCount;
		private List<ToolTipElementModel> _elements = new();
		private ToolTipElementModel _lastRegisteredElement;
		public bool IsActive { get => _toolTipsActive; }
		public event Action OnChange;
		public void NotifyStateChanged() => OnChange?.Invoke();
		public ToolTipState(NavigationManager navigationManager, IJSRuntime jsRuntime) // WASM -> [, HttpClient client, IConfiguration config]
		{
			_navigationManager = navigationManager;
			_jsRuntime = jsRuntime;
			_navigationManager.LocationChanged += NewPage;
			anchorsCount = 0;
		}

		public void ActivateToolTip()
		{
			_toolTipsActive = !_toolTipsActive;
			NotifyStateChanged();
		}

		/// <summary>
		/// Checks if the element is the last one to call JS functions
		/// </summary>
		/// <param name="element"></param>
		public bool IsLastRegisteredElement(ToolTipElementModel element)
		{
			return element == _lastRegisteredElement;
		}

		/// <summary>
		/// Increments the AnchorsCount to ensure each component has a uniqueId
		/// </summary>
		/// <returns></returns>
		public int IncrementAnchorsCount()
		{
			anchorsCount++;
			return anchorsCount;
		}

		/// <summary>
		/// Ensures that all settings are reset when the user navigates to a new page
		/// </summary>
		/// <param name="sender">The Application NavigationManager</param>
		/// <param name="e"></param>
		protected void NewPage(object sender, LocationChangedEventArgs e)
		{
			ResetStateContainer();
			NotifyStateChanged();

		}
		/// <summary>
		/// Resets the state
		/// </summary>
		private void ResetStateContainer()
		{
			_toolTipsActive = false;
			anchorsCount = 0;
			_elements.Clear();
		}
		public async ValueTask DisposeAsync()
		{
			ResetStateContainer();
			_navigationManager.LocationChanged -= NewPage;
		}


		// Adding json file content support

		//TODO : Implement
		//public async Task FetchPageHelpersAsync()
		//{
		//	var result = await _client.GetFromJsonAsync<ToolTipHelper[]>("ToolTipHelpers/helpers.json");
		//	_helpers = result.ToList();

		//}
		//private void InitializeStateContainer()
		//{
		//	if (UsesStaticResources) return;
		//	string path = _navigationManager.ToBaseRelativePath(_navigationManager.Uri);
		//	IEnumerable<string> urlSections = path.ParseUri();
		//	urlSections.ToList().ForEach(u => Console.WriteLine(u));
		//}
	}
}
