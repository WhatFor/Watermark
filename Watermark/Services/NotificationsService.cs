using System.Collections.Generic;
using System.Threading.Tasks;
using Watermark.Models.Admin.Notifications;
using Watermark.Repository.Contracts;
using Watermark.Services.Contracts;

namespace Watermark.Services
{
    public class NotificationsService : INotificationsService
    {
        private readonly INotificationsRepository NotificationsRepository;

        public NotificationsService(INotificationsRepository notificationsRepository)
        {
            NotificationsRepository = notificationsRepository;
        }

        public List<Notification> GetNotifications(string userId, int? count)
        {
            return NotificationsRepository.GetNotifications(userId, count);
        }

        public async Task MarkAllNotificationsRead(string userId)
        {
            await NotificationsRepository.MarkAllNotificationsRead(userId);
        }
    }
}