using Microsoft.EntityFrameworkCore;
using Route.GYM.DAL.Models.Plan;
using Route.GYM.DAL.Persistence.Data.Contexts;

namespace Route.GYM.DAL.Persistence.Repositories.Plans
{
    internal class PlanRepository : IPlanRepository
    {
        #region Fields

        private readonly GymDbContext _dbContext;

        #endregion

        #region Constructor

        public PlanRepository(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        public plan? Get(int id)
        {
            return _dbContext.plans.Find(id);
        }

        public IEnumerable<plan> GetAll(bool WithNoTracking = true)
        {
            if (WithNoTracking)
                return _dbContext.plans.AsNoTracking().ToList();
            else
                return _dbContext.plans.ToList();
        }

        public int Add(plan plan)
        {
            _dbContext.plans.Add(plan);
            return _dbContext.SaveChanges();
        }

        public int Delete(plan plan)
        {
            _dbContext.plans.Remove(plan);
            return _dbContext.SaveChanges();
        }

        public int Update(plan plan)
        {
            _dbContext.plans.Update(plan);
            return _dbContext.SaveChanges();
        }

        #endregion
    }
}
