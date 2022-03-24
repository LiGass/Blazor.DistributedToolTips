using Microsoft.Extensions.DependencyInjection;
using ToolTips.Models;

namespace ToolTips
{
	public static class DependencyInjection
	{
		public static void AddBlazorToolTips(this IServiceCollection services)
		{
			services.AddSingleton<IToolTipState, ToolTipState>();
		}
	}
}
