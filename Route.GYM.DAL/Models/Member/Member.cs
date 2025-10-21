namespace Route.GYM.DAL.Models.Member
{
    public class Member : GymUser.GymUser
    {
        public string? Photo { get; set; }
        public HealthRecord.HealthRecord HealthRecord { get; set; } = null!;
        public ICollection<MemberShip.MemberShip> MemberPlans { get; set; } = null!;
        public ICollection<Booking.Booking> MemberSessions { get; set; } = null!;
    }
}
