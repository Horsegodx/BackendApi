namespace BackendApi.Contracts.Announcement
{
    public class GetAnnouncementsResponse
    {
        public int AnnouncementsId { get; set; }
        public string AnnouncementTopic { get; set; } = null!;
        public string AnnouncementDescription { get; set; } = null!;
        public DateTime AnnouncementDate { get; set; }
    }
}
