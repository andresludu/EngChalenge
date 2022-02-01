using Eng.Data;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services)
        {
            services.AddDbContext<EngContext>();
            services.AddScoped<DbContext, EngContext>(_ => _.GetService<EngContext>());
            return services;
        }
    }
}