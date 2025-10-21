using Route.GYM.DAL.Models.HealthRecord;
using Route.GYM.DAL.Persistence.Data.Contexts;
using Route.GYM.DAL.Persistence.Repositories.Bookings;
using Route.GYM.DAL.Persistence.Repositories.Categories;
using Route.GYM.DAL.Persistence.Repositories.HealthRecords;
using Route.GYM.DAL.Persistence.Repositories.Members;
using Route.GYM.DAL.Persistence.Repositories.MemberShips;
using Route.GYM.DAL.Persistence.Repositories.Plans;
using Route.GYM.DAL.Persistence.Repositories.Sessions;
using Route.GYM.DAL.Persistence.Repositories.Trainers;

namespace Route.GYM.DAL.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GymDbContext _dbContext;
        public IMemberRepository MemberRepository => new MemberRepository(_dbContext);

        public ITrainerRepository TrainerRepository => new TrainerRepository(_dbContext);
        public ICategoryRepository CategoryRepository => new CategoryRepository(_dbContext);
        public IMemberShipRepository MemberShipRepository => new MemberShipRepository(_dbContext);
        public IPlanRepository PlanRepository => new PlanRepository(_dbContext);
        public IHealthRecordRebository HealthRecordRebository => new HealthRacordRepository(_dbContext);
        public IBookingRepository BookingRepository => new BookingRepository(_dbContext);
        public ISessionRepository SessionRepository => new SessionRepository(_dbContext);


        #region Constructor

        public UnitOfWork(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        public int SaveChanges() => _dbContext.SaveChanges();

        public void Dispose() => _dbContext.Dispose();

        #endregion


    }
}
