using Route.GYM.BLL.DTOs.TrainerDTO;

namespace Route.GYM.BLL.Services.Trainers
{
    public interface ITrainerService
    {
        // Get All Trainers
        IEnumerable<TrainersDTO> GetAllTrainers();

        // Get Trainer By Id
        TrainerDetailsDTO? GetTrainerById(int id);

        //Add Trainer
        bool AddTrainer(CreateTrainerDTO createTrainerDTO);

        // Get Trainer To Update
        UpdateTrainerDTO? GetTrainerToUpdate(int trainerId);

        // Update Trainer
        bool UpdateTrainer(int id, UpdateTrainerDTO updateTrainerDTO);

        // Delete Trainer
        bool DeleteTrainer(int IdTrainer);
    }
}
