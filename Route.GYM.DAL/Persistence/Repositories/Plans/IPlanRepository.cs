using Route.GYM.DAL.Models.Plan;

namespace Route.GYM.DAL.Persistence.Repositories.Plans
{
    internal interface IPlanRepository
    {
        // Get all Plan
        IEnumerable<plan> GetAll(bool WithNoTracking = true);

        // Get Plan by id
        plan? Get(int id);

        // Add Plan
        int Add(plan member);

        // Update Plan
        int Update(plan member);

        // Delete Plan
        int Delete(plan member);
    }
}
