using Route.GYM.DAL.Models.Trainer;

namespace Route.GYM.DAL.Persistence.Repositories.Trainers
{
    public interface ITrainerRepository
    {
        // Get all Trainer
        IEnumerable<Trainer> GetAll(bool WithNoTracking = true);

        // Get Trainer by id
        Trainer? Get(int id);

        // Add Trainer
        int Add(Trainer trainer);

        // Update Trainer
        int Update(Trainer trainer);

        // Delete Trainer
        int Delete(Trainer trainer);
    }
}
