namespace Route.GYM.BLL.DTOs.TrainerDTO
{
    public class TrainersDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Specialities { get; set; } = null!;
    }
}
