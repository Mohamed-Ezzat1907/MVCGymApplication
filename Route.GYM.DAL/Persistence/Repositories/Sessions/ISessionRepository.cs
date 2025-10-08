using Route.GYM.DAL.Models.Member;
using Route.GYM.DAL.Models.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.GYM.DAL.Persistence.Repositories.Sessions
{
    internal interface ISessionRepository
    {
        // Get all Session
        IEnumerable<Session> GetAll(bool WithNoTracking = true);

        // Get Session by id
        Session? Get(int id);

        // Add Session
        int Add(Session session);

        // Update Session
        int Update(Session session);

        // Delete Session
        int Delete(Session session);
    }
}
