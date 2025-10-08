using Microsoft.EntityFrameworkCore;
using Route.GYM.DAL.Models.Member;
using Route.GYM.DAL.Persistence.Data.Contexts;

namespace Route.GYM.DAL.Persistence.Repositories.Members
{
    public class MemberRepository : IMemberRepository
    {
        #region Fields

        private readonly GymDbContext _dbContext; 

        #endregion

        #region Constructor

        public MemberRepository(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        public Member? Get(int id)
        {
           return _dbContext.Members.Find(id);
        }

        public IEnumerable<Member> GetAll(bool WithNoTracking = true)
        {
            if(WithNoTracking)
                return _dbContext.Members.AsNoTracking().ToList();
            else
                return _dbContext.Members.ToList();
        }

        public int Add(Member member)
        {
           _dbContext.Members.Add(member);
           return _dbContext.SaveChanges();
        }

        public int Delete(Member member)
        {
          _dbContext.Members.Remove(member);
          return _dbContext.SaveChanges();
        }

        public int Update(Member member)
        {
           _dbContext.Members.Update(member);
           return _dbContext.SaveChanges();
        } 

        #endregion
    }
}
