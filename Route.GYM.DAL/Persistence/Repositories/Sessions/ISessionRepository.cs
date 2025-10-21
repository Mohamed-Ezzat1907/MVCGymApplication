using Route.GYM.DAL.Models.Session;
using Route.GYM.DAL.Persistence.Repositories._Generic;

namespace Route.GYM.DAL.Persistence.Repositories.Sessions
{
    public interface ISessionRepository : IGenericRepository<Session>
    {

        Session? GetSessionWithTrainerAndCategory(int sessionId);
        IEnumerable<Session> GetAllSessionsWithTrainerAndCategory(); 

        int GetCountOfBookedSlots(int sessionId);
    }
}
