using Route.GYM.DAL.Models.Session;
using Route.GYM.DAL.Persistence.Data.Contexts;
using Route.GYM.DAL.Persistence.Repositories._Generic;

namespace Route.GYM.DAL.Persistence.Repositories.Sessions
{
    public class SessionRepository : GenericRepository<Session>, ISessionRepository
    {
        public SessionRepository(GymDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
