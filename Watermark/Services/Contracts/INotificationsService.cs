using System.Collections.Generic;
using System.Threading.Tasks;
using Watermark.Models.Admin.Notifications;

namespace Watermark.Services.Contracts
{
    public interface INotificationsService
    {
        List<Notification> GetNotifications(string userId, int? count);

        Task MarkAllNotificationsRead(string userId);
    }
}