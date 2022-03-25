using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
namespace DistributedToolTips.Models
{
	public interface IToolTipState : IDisposable
	{
		event Action OnChange;
		void NotifyStateChanged();
		void ActivateToolTip();
		int IncrementAnchorsCount();
		Task FetchPageHelpersAsync();
		bool IsActive { get; }
	}
	public class ToolTipState : IToolTipState
	{
		private readonly string ResourcePath = string.Empty;
		private bool UsesStaticResources { get => ResourcePath != string.Empty;}
		private readonly NavigationManager _navigationManager;
		private readonly IConfiguration _config;
		private readonly HttpClient _client;
		private bool _toolTipsActive = false;
		private int anchorsCount;
		private List<ToolTipHelper> _helpers = new();
		public bool IsActive { get => _toolTipsActive; }
		public event Action OnChange;
		public void NotifyStateChanged() => OnChange?.Invoke();
		public ToolTipState(NavigationManager navigationManager, HttpClient client, IConfiguration config)
		{
			_navigationManager = navigationManager;
			_config = config;
			ResourcePath = _config["DistributedToolTips.ResourceFolder"];
			_client = client;
			_navigationManager.LocationChanged += NewPage;
			anchorsCount = 0;
			Console.WriteLine(_navigationManager.Uri);
		}
		private void ResetStateContainer()
		{
			_toolTipsActive = false;
			anchorsCount = 0;
			_helpers.Clear();
		}
		protected void NewPage(object sender, LocationChangedEventArgs e)
		{
			ResetStateContainer();
			//InitializeStateContainer();
			Console.WriteLine(e.Location);
		}

		public async Task FetchPageHelpersAsync()
		{
			var result = await _client.GetFromJsonAsync<ToolTipHelper[]>("ToolTipHelpers/helpers.json");
			_helpers = result.ToList();

		}
		private  void InitializeStateContainer()
		{
			if (UsesStaticResources) return;
			string path = _navigationManager.ToBaseRelativePath(_navigationManager.Uri);
			IEnumerable<string> urlSections = path.ParseUri();
			urlSections.ToList().ForEach(u=>Console.WriteLine(u));
		}




		public void ActivateToolTip()
		{
			_toolTipsActive = !_toolTipsActive;
			Console.WriteLine(_navigationManager.Uri);
			NotifyStateChanged();
		}
		public int IncrementAnchorsCount()
		{
			anchorsCount++;
			return anchorsCount;
		}
		public void Dispose()
		{
			ResetStateContainer();
			_navigationManager.LocationChanged -= NewPage;
		}
	}
}
