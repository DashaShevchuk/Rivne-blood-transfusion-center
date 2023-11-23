using Microsoft.AspNetCore.Identity;
using RivneBloodTransfusionCenter.Data.Entities.AppUsers;
using RivneBloodTransfusionCenter.Data.EfDbContext;

namespace RivneBloodTransfusionCenter.Data.SeedData
{
    public class Seed
    {
        public static async Task SeedData(IServiceProvider services, IHostEnvironment env, IConfiguration config)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var manager = scope.ServiceProvider.GetRequiredService<UserManager<DbUser>>();
                var managerRole = scope.ServiceProvider.GetRequiredService<RoleManager<DbRole>>();
                var context = scope.ServiceProvider.GetRequiredService<EfContext>();
                await PreConfigured.SeedRoles(managerRole);
                await PreConfigured.SeedSexes(context);
                await PreConfigured.SeedUsers(manager, context);
                await PreConfigured.SeedBloodTypes(context);
                await PreConfigured.SeedDonationTypes(context);
                await PreConfigured.SeedSicknesses(context);
            }
        }
    }
}
