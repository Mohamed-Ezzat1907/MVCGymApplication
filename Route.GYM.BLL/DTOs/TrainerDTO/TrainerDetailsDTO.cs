using Route.GYM.DAL.Models.Enum;

namespace Route.GYM.BLL.DTOs.TrainerDTO
{
    public class TrainerDetailsDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public Specialities Specialities { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public int BuidingNumber { get; set; }
        public string Street { get; set; } = null!;
        public string City { get; set; } = null!;
    }
}
