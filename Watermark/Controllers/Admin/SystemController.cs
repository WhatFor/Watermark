using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Watermark.Repository;

namespace Watermark.Controllers.Admin
{
    [Route("System")]
    public class SystemController : Controller
    {
        private readonly WatermarkDbContext dbContext;

        public SystemController(WatermarkDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("Migrate")]
        [AllowAnonymous]
        public async Task MigrateEFDatabase()
        {
            await dbContext.Database.MigrateAsync();
        }
    }
}
