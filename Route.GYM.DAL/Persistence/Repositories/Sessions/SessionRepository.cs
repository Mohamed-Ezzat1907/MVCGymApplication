using Microsoft.EntityFrameworkCore;
using Route.GYM.DAL.Models.Session;
using Route.GYM.DAL.Persistence.Data.Contexts;
using Route.GYM.DAL.Persistence.Repositories._Generic;

namespace Route.GYM.DAL.Persistence.Repositories.Sessions
{
    public class SessionRepository : GenericRepository<Session>, ISessionRepository
    {
        private readonly GymDbContext _dbContext;
        public SessionRepository(GymDbContext dbcontext) : base(dbcontext)
        {
            _dbContext = dbcontext;
        }

        #region Methods

        // GetAllSessionsWithTrainerAndCategory
        public IEnumerable<Session> GetAllSessionsWithTrainerAndCategory()
        {
            return _dbContext.Sessions
                             .Include(s => s.Trainer)
                             .Include(s => s.Category)
                             .ToList();
                                        
        }

        // GetCountOfBookedSlots
        public int GetCountOfBookedSlots(int sessionId)
        {
            return _dbContext.Bookings.Where(b => b.SessionId == sessionId).Count();
        }

        // GetSessionWithTrainerAndCategory(
        public Session? GetSessionWithTrainerAndCategory(int sessionId)
        {
            return _dbContext.Sessions
                             .Include(s => s.Trainer)
                             .Include(s => s.Category)
                             .FirstOrDefault(s => s.Id == sessionId);
        }

        #endregion
    }
}
