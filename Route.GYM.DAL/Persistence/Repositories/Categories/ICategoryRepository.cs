using Route.GYM.DAL.Models.Category;

namespace Route.GYM.DAL.Persistence.Repositories.Categories
{
    public interface ICategoryRepository
    {
        // Get all Category
        IEnumerable<Category> GetAll(bool WithNoTracking = true);

        // Get Category by id
        Category? Get(int id);

        // Add Category
        int Add(Category category);

        // Update Category
        int Update(Category category);

        // Delete Category
        int Delete(Category category);
    }
}
