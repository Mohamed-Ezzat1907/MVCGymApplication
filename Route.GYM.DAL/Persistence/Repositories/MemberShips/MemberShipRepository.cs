using Route.GYM.DAL.Models.MemberShip;
using Route.GYM.DAL.Persistence.Data.Contexts;
using Route.GYM.DAL.Persistence.Repositories._Generic;

namespace Route.GYM.DAL.Persistence.Repositories.MemberShips
{
    public class MemberShipRepository : GenericRepository<MemberShip>, IMemberShipRepository
    {
        public MemberShipRepository(GymDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
