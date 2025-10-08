namespace Route.GYM.DAL.Models.Booking
{
    public class Booking : BaseEntity
    {

        public int MemberId { get; set; }
        public Member.Member Member { get; set; } = null!;
        public int SessionId { get; set; }
        public Session.Session Session { get; set; } = null!;
        public bool IsAttended { get; set; }

    }
}
