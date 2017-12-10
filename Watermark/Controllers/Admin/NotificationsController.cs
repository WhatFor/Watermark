using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Watermark.Models;
using Watermark.Services.Contracts;

namespace Watermark.Controllers.Admin
{
    [Route("Admin/[controller]/[action]")]
    public class NotificationsController : Controller
    {
        private readonly INotificationsService NotificationsService;
        private readonly UserManager<ApplicationUser> UserManager;

        public NotificationsController(INotificationsService notificationsService, UserManager<ApplicationUser> userManager)
        {
            NotificationsService = notificationsService;
            UserManager = userManager;

        }

        [HttpGet]
        public JsonResult GetNotifications([FromQuery]int? count)
        {
            var userId = UserManager.GetUserId(User);

            var notifications = NotificationsService.GetNotifications(userId, count);
            return Json(notifications);
        }

        public async Task MarkAllRead()
        {
            var userId = UserManager.GetUserId(User);

            await NotificationsService.MarkAllNotificationsRead(userId);
        }
    }
}