using Microsoft.AspNetCore.Builder;

namespace Watermark.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static void SeedWebData(this IApplicationBuilder app)
        {
            SeedApplicationRoles();
            SeedAdminAccounts();
        }

        private static void SeedApplicationRoles()
        {
        }

        private static void SeedAdminAccounts()
        {
        }
    }
}