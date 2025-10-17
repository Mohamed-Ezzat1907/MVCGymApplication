using Route.GYM.DAL.Models;

namespace Route.GYM.DAL.Persistence.Repositories._Generic
{
    public interface IGenericRepository <T> where T : BaseEntity
    {
        // Get all entity
        IEnumerable<T> GetAll( Func<T, bool>? condition = null );

        // Get entity by id
        T? Get(int id);

        // Add entity
        void Add(T entity);

        // Update entity
        void Update(T entity);

        // Delete entity
        void Delete(T entity);
    }
}
