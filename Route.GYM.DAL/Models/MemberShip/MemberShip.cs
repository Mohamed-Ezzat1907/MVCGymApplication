namespace Route.GYM.DAL.Models.MemberShip
{
    public class MemberShip : BaseEntity
    {
        public DateTime EndDate { get; set; }
        public string Status {
            get
            {
                if (EndDate >= DateTime.Now)
                    return "Active";
                else
                    return "Expired";
            }
        }
        public int MemberId { get; set; }
        public Member.Member Member { get; set; } 
        public int PlanId { get; set; }
        public Plan.plan Plan { get; set; }
    }
}
