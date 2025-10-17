using AutoMapper;
using Route.GYM.BLL.DTOs.SessionDTO;
using Route.GYM.DAL.Models.Session;
using Route.GYM.DAL.Persistence.UnitOfWork;

namespace Route.GYM.BLL.Services.Sessions
{
    public class SessionService : ISessionService
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public SessionService(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        // Get All Sessions
        public IEnumerable<SessionDTO> GetAllSessions()
        {
            var sessions = _unitOfWork.SessionRepository.GetAllSessionsWithTrainerAndCategory().OrderBy(s => s.StartDate);

            if (sessions is null || !sessions.Any())
                return [];

            var mappedSessions = _mapper.Map<IEnumerable<Session> , IEnumerable<SessionDTO>>(sessions);

            foreach (var session in mappedSessions)
                session.AvailableSlots = session.Capacity - _unitOfWork.SessionRepository.GetCountOfBookedSlots(session.Id);

            return mappedSessions;
        }

        // Get Sesssion By Id
        public SessionDTO? GetSessionById(int seesionId)
        {
            var session = _unitOfWork.SessionRepository.GetSessionWithTrainerAndCategory(seesionId);

            if (session is null)
                return null;

            var mappedSession = _mapper.Map<Session, SessionDTO>(session);

            mappedSession.AvailableSlots = session.Capacity - _unitOfWork.SessionRepository.GetCountOfBookedSlots(session.Id);

            return mappedSession;
        }

        // Create Session
        public bool CreateSession(CreateSessionDTO input)
        {
            if (ISTrainerExist(input.TrainerId))
                return false;

            if(ISCategoryExist(input.CategoryId))
                return false;

            if(IsValidDate(input.StartDate , input.EndDate))
                return false;

            var session = _mapper.Map<CreateSessionDTO, Session>(input);

            _unitOfWork.SessionRepository.Add(session);

            return _unitOfWork.SaveChanges() > 0;
        }


        // Get Session To Update
        public UpdateSessionDTO? GetSessionToUpdate(int sessionid)
        {
            var session = _unitOfWork.SessionRepository.Get(sessionid);
            if (session is null)
                return null;

            return _mapper.Map<UpdateSessionDTO>(session);

        }
        // Update Session
        public bool UpdateSession(int sessionId, UpdateSessionDTO input)
        {
            var session = _unitOfWork.SessionRepository.Get(sessionId);

            if (session is null)
                return false;

           if (!IsSessionAvailableForUpdate(session))
                return false;

            if (ISTrainerExist(input.TrainerId))
                return false;

            if (IsValidDate(input.StartDate, input.EndDate))
                return false;

            _mapper.Map<UpdateSessionDTO , Session>(input);

            session.UpdatedAt = DateTime.Now;

            _unitOfWork.SessionRepository.Update(session);

            return _unitOfWork.SaveChanges() > 0;
        }

        // Delete Session
        public bool DeleteSession(int sessionId)
        {
            var session = _unitOfWork.SessionRepository.Get(sessionId);

            if (session is null)
                return false;

            if(IsSessionAvailableForDelete(session))
                return false;

            _unitOfWork.SessionRepository.Delete(session);

            return _unitOfWork.SaveChanges() > 0;
        }

        #endregion

        #region Helper Methods

        private bool ISTrainerExist(int trainerId)
        {
            var trainer = _unitOfWork.TrainerRepository.Get(trainerId);

            return trainer is null ? false : true;
        }

        private bool ISCategoryExist(int categoryId)
        {
            var category = _unitOfWork.CategoryRepository.Get(categoryId);

            return category is null ? false : true;
        }

        private bool IsValidDate(DateTime startDate , DateTime endDate)
        {
            return endDate > startDate && startDate > DateTime.Now;
        }

        private bool IsSessionAvailableForUpdate(Session session) 
        { 
            if (session is null) 
                return false;

            if(session.EndDate < DateTime.Now)
                return false;

            if (session.StartDate <= DateTime.Now)
                return false;

            var hasActiveBookings = _unitOfWork.SessionRepository.GetCountOfBookedSlots(session.Id) > 0;

            if (hasActiveBookings)
                return false;

            return true;
        }

        private bool IsSessionAvailableForDelete(Session session)
        {
            if (session is null)
                return false;

            if (session.StartDate > DateTime.Now)
                return false;

            if (session.StartDate <= DateTime.Now && session.EndDate > DateTime.Now)
                return false;

            var hasActiveBookings = _unitOfWork.SessionRepository.GetCountOfBookedSlots(session.Id) > 0;

            if (hasActiveBookings)
                return false;

            return true;
        }

        #endregion
    }
}
