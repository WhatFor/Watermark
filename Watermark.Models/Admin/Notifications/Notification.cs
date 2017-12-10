using System;

namespace Watermark.Models.Admin.Notifications
{
    public class Notification
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public bool Read { get; set; } = false;

        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset? DateRead { get; set; }
    }
}