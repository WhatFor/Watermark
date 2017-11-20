using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using Watermark.Models.Admin;
using Watermark.Models.Site;
using Microsoft.Extensions.DependencyInjection;

namespace Watermark.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static async Task SeedWebData(this IApplicationBuilder app, UserManager<ApplicationUser> uManager, RoleManager<IdentityRole> rManager)
        {
            var db = app.ApplicationServices.GetService<AdminDbContext>();

            await SeedApplicationRoles(rManager);
            await SeedAdminAccounts(db, uManager);
        }

        private static async Task SeedApplicationRoles(RoleManager<IdentityRole> rManager)
        {
            var adminRole = await rManager.FindByNameAsync("Admin");

            if (adminRole == null)
            {
                await rManager.CreateAsync(new IdentityRole("Admin"));
            }
        }

        private static async Task SeedAdminAccounts(AdminDbContext db, UserManager<ApplicationUser> uManager)
        {
            var userToAdd = new ApplicationUser { UserName = "Admin", Email = "admin@watermark.com" };

            var dbUser = uManager.Users.SingleOrDefault(m => m.UserName == userToAdd.UserName);

            if (dbUser == null)
            {
                var result = await uManager.CreateAsync(userToAdd, "Watermark1");
                if (result.Succeeded)
                {
                    await uManager.AddToRoleAsync(userToAdd, "Admin");
                }
            }
        }
    }
}