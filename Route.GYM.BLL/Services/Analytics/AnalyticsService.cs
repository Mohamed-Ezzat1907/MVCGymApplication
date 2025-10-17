using Route.GYM.BLL.DTOs.Analytics;
using Route.GYM.DAL.Persistence.UnitOfWork;

namespace Route.GYM.BLL.Services.Analytics
{
    public class AnalyticsService : IAnalyticsService
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork; 

        #endregion

        #region Constructor

        public AnalyticsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public AnalyticsDTO GetAnalyticsData()
        {
            return new AnalyticsDTO
            {
                ActiveMembers = _unitOfWork.MemberShipRepository.GetAll(ms => ms.Status == "Active").Count(),
                TotalMembers = _unitOfWork.MemberRepository.GetAll().Count(),
                TotalTrainers = _unitOfWork.TrainerRepository.GetAll().Count(),
                UpComingSessions = _unitOfWork.SessionRepository.GetAll(s => s.StartDate > DateTime.Now).Count(),
                OnGoingSessions = _unitOfWork.SessionRepository.GetAll(s => s.StartDate <= DateTime.Now && s.EndDate >= DateTime.Now).Count(),
                CompletedSessions = _unitOfWork.SessionRepository.GetAll(s => s.EndDate < DateTime.Now).Count(),
            };
        } 

        #endregion
    }
}
