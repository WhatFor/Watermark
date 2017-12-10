using Microsoft.AspNetCore.Identity;

namespace Watermark.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsFirstLogin { get; set; } = true;
    }
}