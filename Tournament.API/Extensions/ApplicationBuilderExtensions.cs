using Microsoft.EntityFrameworkCore;
using Tournament.Data.Data;

namespace Tournament.API.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task SeedDataAsync(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var context = serviceProvider.GetRequiredService<TournamentContext>();

                // To Delete all Data
                //await context.Database.EnsureDeletedAsync();
                //await context.Database.MigrateAsync();

                try
                {
                    await SeedData.InitAsync(context);
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }
    }
}
