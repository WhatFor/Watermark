using System.Threading.Tasks;
using Watermark.Repository.Contracts;
using Watermark.Services.Contracts;

namespace Watermark.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IApplicationUserRepository UserRepository;

        public ApplicationUserService(IApplicationUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public async Task SetUserFirstLoginTutorialComplete(string userId)
        {
            await UserRepository.SetUserFirstLoginTutorialComplete(userId);
        }
    }
}
