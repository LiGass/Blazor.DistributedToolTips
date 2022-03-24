using Microsoft.Extensions.DependencyInjection;
using ToolTipComponent.Models;

namespace ToolTipComponent
{
	public static class DependencyInjection
	{
		public static void AddBlazorToolTips(this IServiceCollection services)
		{
			services.AddSingleton<IToolTipState, ToolTipState>();
		}
	}
}
