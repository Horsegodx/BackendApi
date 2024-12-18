namespace BackendApi.Contracts.Announcement
{
    public class CreateAnnouncementsRequest
    {
        public string AnnouncementTopic { get; set; } = null!;
        public string AnnouncementDescription { get; set; } = null!;
        public DateTime AnnouncementDate { get; set; }
    }
}
