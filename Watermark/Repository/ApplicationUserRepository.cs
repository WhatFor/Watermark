using System.Linq;
using System.Threading.Tasks;
using Watermark.Models;
using Watermark.Repository.Contracts;

namespace Watermark.Repository
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly WatermarkDbContext DbContext;

        public ApplicationUserRepository(WatermarkDbContext dbContext)
        {
            DbContext = dbContext;
        }

         public async Task SetUserFirstLoginTutorialComplete(string userId)
        {
            var user = DbContext.Users.SingleOrDefault(m => m.Id == userId);

            user.IsFirstLogin = false;

            await DbContext.SaveChangesAsync();
        }
    }
}