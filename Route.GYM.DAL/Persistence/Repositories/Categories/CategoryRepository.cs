using Microsoft.EntityFrameworkCore;
using Route.GYM.DAL.Models.Category;
using Route.GYM.DAL.Persistence.Data.Contexts;

namespace Route.GYM.DAL.Persistence.Repositories.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        #region Fields

        private readonly GymDbContext _dbContext;

        #endregion

        #region Constructor

        public CategoryRepository(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        public Category? Get(int id)
        {
            return _dbContext.Categories.Find(id);
        }

        public IEnumerable<Category> GetAll(bool WithNoTracking = true)
        {
            if (WithNoTracking)
                return _dbContext.Categories.AsNoTracking().ToList();
            else
                return _dbContext.Categories.ToList();
        }

        public int Add(Category category)
        {
            _dbContext.Categories.Add(category);
            return _dbContext.SaveChanges();
        }

        public int Delete(Category category)
        {
            _dbContext.Categories.Remove(category);
            return _dbContext.SaveChanges();
        }

        public int Update(Category category)
        {
           _dbContext.Categories.Update(category);
           return _dbContext.SaveChanges();
        }

        #endregion
    }
}
