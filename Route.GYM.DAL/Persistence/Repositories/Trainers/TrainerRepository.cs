using Route.GYM.DAL.Models.Trainer;
using Route.GYM.DAL.Persistence.Data.Contexts;
using Route.GYM.DAL.Persistence.Repositories._Generic;

namespace Route.GYM.DAL.Persistence.Repositories.Trainers
{
    public class TrainerRepository : GenericRepository<Trainer>, ITrainerRepository
    {
        public TrainerRepository(GymDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
