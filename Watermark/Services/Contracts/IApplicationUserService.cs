using System.Threading.Tasks;

namespace Watermark.Services.Contracts
{
    public interface IApplicationUserService
    {
        Task SetUserFirstLoginTutorialComplete(string userId);
    }
}