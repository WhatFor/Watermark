using Microsoft.AspNetCore.Mvc.Filters;

namespace Watermark.Models.Admin
{
    public class AdminAuthorizationAttribute : ResultFilterAttribute
    {
        public AdminAuthorizationAttribute()
        {
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            // Todo: Validate on role
        }
    }
}