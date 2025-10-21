namespace Route.GYM.BLL.DTOs.Analytics
{
    public class AnalyticsDTO
    {
        public int TotalMembers { get; set; }
        public int ActiveMembers { get; set; }
        public int TotalTrainers { get; set; }
        public int UpComingSessions { get; set; }
        public int OnGoingSessions { get; set; }
        public int CompletedSessions { get; set; }
    }
}
