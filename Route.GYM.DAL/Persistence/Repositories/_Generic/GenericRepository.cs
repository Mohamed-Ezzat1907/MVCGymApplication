using Microsoft.EntityFrameworkCore;
using Route.GYM.DAL.Models;
using Route.GYM.DAL.Persistence.Data.Contexts;

namespace Route.GYM.DAL.Persistence.Repositories._Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        #region Fields

        private readonly GymDbContext _dbContext; 

        #endregion

        #region Constructor

        public GenericRepository(GymDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        #endregion

        #region Methods

        public T? Get(int id)
            => _dbContext.Set<T>().Find(id);
        

        public IEnumerable<T> GetAll( Func<T, bool>? condition = null)
        {
            if (condition is not null)
                return _dbContext.Set<T>().AsNoTracking().Where(condition).ToList();
            else
                return _dbContext.Set<T>().ToList();
        }

        public void Add(T entity)
            => _dbContext.Set<T>().Add(entity);

        public void Delete(T entity)
            => _dbContext.Set<T>().Remove(entity);

        public void Update(T entity)
            => _dbContext.Set<T>().Update(entity);

        #endregion
    }
}
