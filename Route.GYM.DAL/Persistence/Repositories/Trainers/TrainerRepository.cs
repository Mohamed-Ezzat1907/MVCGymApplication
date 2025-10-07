using Microsoft.EntityFrameworkCore;
using Route.GYM.DAL.Models.Trainer;
using Route.GYM.DAL.Persistence.Data.Contexts;

namespace Route.GYM.DAL.Persistence.Repositories.Trainers
{
    public class TrainerRepository : ITrainerRepository
    {
        #region Fields

        private readonly GymDbContext _dbContext;

        #endregion

        #region Constructor

        public TrainerRepository(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        public Trainer? Get(int id)
        {
            return _dbContext.Trainers.Find(id);
        }

        public IEnumerable<Trainer> GetAll(bool WithNoTracking = true)
        {
            if (WithNoTracking)
                return _dbContext.Trainers.AsNoTracking().ToList();
            else
                return _dbContext.Trainers.ToList();
        }

        public int Add(Trainer trainer)
        {
           _dbContext.Trainers.Add(trainer);
           return _dbContext.SaveChanges();
        }

        public int Delete(Trainer trainer)
        {
            _dbContext.Trainers.Remove(trainer);
            return _dbContext.SaveChanges();
        }

        public int Update(Trainer trainer)
        {
            _dbContext.Trainers.Update(trainer);
            return _dbContext.SaveChanges();
        }

        #endregion
    }
}
