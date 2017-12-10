using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Watermark.Models.Admin.Notifications;
using Watermark.Repository.Contracts;

namespace Watermark.Repository
{
    public class NotificationsRepository : INotificationsRepository
    {
        private readonly WatermarkDbContext DbContext;

        public NotificationsRepository(WatermarkDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public List<Notification> GetNotifications(string userId, int? count)
        {
            if (count != null)
            {
                return DbContext.Notifications.Where(m => m.UserId == userId && !m.Read).Take(count.Value).ToList();
            }
            else
            {
                return DbContext.Notifications.Where(m => m.UserId == userId && !m.Read).ToList();
            }
        }

        public async Task MarkAllNotificationsRead(string userId)
        {
           var notifications = DbContext.Notifications.Where(m => m.UserId == userId);

            foreach (var notification in notifications)
            {
                notification.Read = true;
                notification.DateRead = DateTimeOffset.Now;
            }

            await DbContext.SaveChangesAsync();
        }
    }
}