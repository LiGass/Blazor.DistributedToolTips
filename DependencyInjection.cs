using DistributedToolTips.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace DistributedToolTips
{
	public static class DependencyInjection
    {
        public static void AddBlazorToolTips(this IServiceCollection services)
        {
            services.AddScoped<IToolTipState, ToolTipState>();
        }

    }
}
