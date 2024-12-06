using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Announcement
    {
        public int AnnouncementsId { get; set; }
        public string AnnouncementTopic { get; set; } = null!;
        public string AnnouncementDescription { get; set; } = null!;
        public DateTime AnnouncementDate { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
