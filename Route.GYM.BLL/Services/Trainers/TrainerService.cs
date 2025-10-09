using Route.GYM.BLL.DTOs.TrainerDTO;
using Route.GYM.DAL.Models.Address;
using Route.GYM.DAL.Models.Trainer;
using Route.GYM.DAL.Persistence.UnitOfWork;

namespace Route.GYM.BLL.Services.Trainers
{
    public class TrainerService : ITrainerService
    {
        #region Field

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public TrainerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        // Get All Trainers
        public IEnumerable<TrainersDTO> GetAllTrainers()
        {
            var trainers = _unitOfWork.TrainerRepository.GetAll() ?? [];
            if (trainers is null || !trainers.Any())
                return [];

            return trainers.Select(t => new TrainersDTO
            {
                Name = t.Name,
                Email = t.Email,
                Phone = t.Phone,
                Specialities = t.Specialities.ToString()
            });
        }

        // Get Trainer By Id
        public TrainerDetailsDTO? GetTrainerById(int id) 
        {
            var trainer = _unitOfWork.TrainerRepository.Get(id);

            if (trainer is null)
                return null;

            var TrainerViewModel = new TrainerDetailsDTO
            {
                Name = trainer.Name,
                Specialities = trainer.Specialities.ToString(),
                Email = trainer.Email,
                Phone = trainer.Phone,
                DateOfBirth = trainer.DateOfBirth.ToShortDateString(),
                Address = FormatAddress(trainer.Address),
            };

            return TrainerViewModel;
        }

        // Add Trainer
        public bool AddTrainer(CreateTrainerDTO createTrainerDTO)
        {
            try
            {
                if (IsEmailExist(createTrainerDTO.Email) || IsPhoneExist(createTrainerDTO.Phone))
                    return false;
                var trainer = new Trainer
                {
                    Name = createTrainerDTO.Name,
                    Email = createTrainerDTO.Email,
                    Phone = createTrainerDTO.Phone,
                    Gender = createTrainerDTO.Gender,
                    DateOfBirth = createTrainerDTO.DateOfBirth,
                    Address = new Address
                    {
                        BuidingNumber = createTrainerDTO.BuidingNumber,
                        Street = createTrainerDTO.Street,
                        City = createTrainerDTO.City,
                    },
                    Specialities = createTrainerDTO.Specialities,
                };
                _unitOfWork.TrainerRepository.Add(trainer);

                return true;
            }
            catch 
            {
                return false;
            }
        }

        // Get Trainer To Update
        public UpdateTrainerDTO? GetTrainerToUpdate(int trainerId)
        {
            var trainer = _unitOfWork.TrainerRepository.Get(trainerId);

            if (trainer is null)
                return null;

            var updateTrainerDTO = new UpdateTrainerDTO
            {
                Name = trainer.Name,
                Email = trainer.Email,
                BuidingNumber = trainer.Address.BuidingNumber,
                Street = trainer.Address.Street,
                City = trainer.Address.City,
            };

            return updateTrainerDTO;
        }

        // Update Trainer
        public bool UpdateTrainer(int id, UpdateTrainerDTO updateTrainerDTO) 
        {
            var trainer = _unitOfWork.TrainerRepository.Get(id);

            if (trainer is null)
                return false;

            if (IsEmailExist(updateTrainerDTO.Email) || IsPhoneExist(updateTrainerDTO.Phone))
                return false;

            trainer.Email = updateTrainerDTO.Email;
            trainer.Phone = updateTrainerDTO.Phone;
            trainer.Address.BuidingNumber = updateTrainerDTO.BuidingNumber;
            trainer.Address.Street = updateTrainerDTO.Street;
            trainer.Address.City = updateTrainerDTO.City;
            trainer.Specialities = updateTrainerDTO.Specialities;
            trainer.UpdatedAt = DateTime.Now;

            _unitOfWork.TrainerRepository.Update(trainer);
            return true;
        }

        // Delete Trainer
        public bool DeleteTrainer(int IdTrainer)
        {
            var trainer = _unitOfWork.TrainerRepository.Get(IdTrainer);

            if (trainer is null)
                return false;

            var ActiveSession = _unitOfWork.SessionRepository
                                       .GetAll(s => s.TrainerId == IdTrainer && s.StartDate > DateTime.UtcNow);

            try
            {
                if (ActiveSession.Any())
                    _unitOfWork.TrainerRepository.Delete(trainer);
                return true;
            }
            catch 
            {
                return false;
            }
        }

        #endregion

        #region Helper Methods

        private string FormatAddress(Address address)
        {
            if (address is null)
                return string.Empty;

            return $"{address.BuidingNumber} , {address.Street} , {address.City}";
        }

        private bool IsEmailExist(string email)
        {
            var exitingTrainer = _unitOfWork.TrainerRepository
                         .GetAll(m => m.Email.ToLower() == email.ToLower());

            return exitingTrainer is not null && exitingTrainer.Any();
        }

        private bool IsPhoneExist(string phone)
        {
            var exitingTrainer = _unitOfWork.TrainerRepository
                         .GetAll(m => m.Phone.ToLower() == phone.ToLower());
            return exitingTrainer is not null && exitingTrainer.Any();
        }

        #endregion

    }
}
