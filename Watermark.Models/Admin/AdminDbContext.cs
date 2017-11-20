using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Watermark.Models.Site;

namespace Watermark.Models.Admin
{
    public class AdminDbContext : IdentityDbContext<ApplicationUser>
    {
        public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options)
        {
        }
    }
}