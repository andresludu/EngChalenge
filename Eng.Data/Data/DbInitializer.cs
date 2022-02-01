using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Eng.Data.Data
{
  public class DbInitializer
    {
        public static async Task Initialize(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            var dbDataContext = serviceScope.ServiceProvider.GetRequiredService<EngContext>();
            // Ensure that the database exists and all pending migrations are applied.
            await dbDataContext.Database.MigrateAsync();

        }
    }
}
