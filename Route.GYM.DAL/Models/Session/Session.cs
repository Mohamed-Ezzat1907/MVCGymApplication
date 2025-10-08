namespace Route.GYM.DAL.Models.Session
{
    public class Session : BaseEntity
    {
        public string Description { get; set; } = null!;
        public int Capacity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<Booking.Booking> SessionMembers { get; set; } = null!;
        public int TrainerId { get; set; }
        public Trainer.Trainer Trainer { get; set; } = null!;
        public int CategoryId { get; set; }
        public Category.Category Category { get; set; } = null!;
    }
}
