using Route.GYM.DAL.Models.Enum;

namespace Route.GYM.DAL.Models.Trainer
{
    public class Trainer : GymUser.GymUser
    {
        public Specialities Specialities { get; set; }
        public ICollection<Session.Session> Sessions { get; set; } = null!;
    }
}
