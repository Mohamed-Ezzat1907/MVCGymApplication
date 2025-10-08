using Microsoft.EntityFrameworkCore;
using Route.GYM.DAL.Models.Member;
using Route.GYM.DAL.Models.Session;
using Route.GYM.DAL.Persistence.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Route.GYM.DAL.Persistence.Repositories.Sessions
{
    internal class SessionRepository : ISessionRepository
    {
        #region Fields

        private readonly GymDbContext _dbContext;

        #endregion

        #region Constructor

        public SessionRepository(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        public Session? Get(int id)
        {
            return _dbContext.Sessions.Find(id);
        }

        public IEnumerable<Session> GetAll(bool WithNoTracking = true)
        {
            if (WithNoTracking)
                return _dbContext.Sessions.AsNoTracking().ToList();
            else
                return _dbContext.Sessions.ToList();
        }

        public int Add(Session session)
        {
            _dbContext.Sessions.Add(session);
            return _dbContext.SaveChanges();
        }

        public int Delete(Session session)
        {
            _dbContext.Sessions.Remove(session);
            return _dbContext.SaveChanges();
        }

        public int Update(Session session)
        {
            _dbContext.Sessions.Update(session);
            return _dbContext.SaveChanges();
        }

        #endregion
    }
}
