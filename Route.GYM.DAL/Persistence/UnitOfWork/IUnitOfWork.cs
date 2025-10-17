using Route.GYM.DAL.Persistence.Repositories.Bookings;
using Route.GYM.DAL.Persistence.Repositories.HealthRecords;
using Route.GYM.DAL.Persistence.Repositories.Members;
using Route.GYM.DAL.Persistence.Repositories.MemberShips;
using Route.GYM.DAL.Persistence.Repositories.Plans;
using Route.GYM.DAL.Persistence.Repositories.Sessions;
using Route.GYM.DAL.Persistence.Repositories.Trainers;

namespace Route.GYM.DAL.Persistence.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public IMemberRepository MemberRepository { get; }
        public ITrainerRepository TrainerRepository { get; }
        public IMemberShipRepository MemberShipRepository { get; }
        public IPlanRepository  PlanRepository { get; }
        public IHealthRecordRebository HealthRecordRebository { get; }
        public IBookingRepository BookingRepository { get; }
        public ISessionRepository SessionRepository { get; }

        int SaveChanges();
    }
}
