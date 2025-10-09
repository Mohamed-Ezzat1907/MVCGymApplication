using Route.GYM.DAL.Models.Plan;
using Route.GYM.DAL.Persistence.Data.Contexts;
using Route.GYM.DAL.Persistence.Repositories._Generic;

namespace Route.GYM.DAL.Persistence.Repositories.Plans
{
    public class PlanRepository : GenericRepository<plan>, IPlanRepository
    {
        public PlanRepository(GymDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
