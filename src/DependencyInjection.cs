
using Microsoft.Extensions.DependencyInjection;

namespace ToolTips
{
	public static class DependencyInjection
    {
        public static void AddBlazorToolTips(this IServiceCollection services)
        {
            services.AddScoped<IToolTipService, ToolTipService>();
        }

    }
}
