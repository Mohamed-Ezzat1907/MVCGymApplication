namespace Route.GYM.BLL.DTOs.MemberDTO
{
    public class MemberDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string DateOfBirth { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? Photo { get; set; }
        public string? PlanName { get; set; }
        public string? MemberShipStartDate { get; set; } = null;
        public string? MemberShipEndDate { get; set; } = null;
    }

}
