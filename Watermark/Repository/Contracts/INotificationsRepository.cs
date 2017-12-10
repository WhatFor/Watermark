using System.Collections.Generic;
using System.Threading.Tasks;
using Watermark.Models.Admin.Notifications;

namespace Watermark.Repository.Contracts
{
    public interface INotificationsRepository
    {
        List<Notification> GetNotifications(string userId, int? count);

        Task MarkAllNotificationsRead(string userId);
    }
}
