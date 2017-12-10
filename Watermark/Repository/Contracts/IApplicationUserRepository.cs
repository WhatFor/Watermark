using System.Threading.Tasks;
using Watermark.Models;

namespace Watermark.Repository.Contracts
{
    public interface IApplicationUserRepository
    {
        Task SetUserFirstLoginTutorialComplete(string userId);
    }
}