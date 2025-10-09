using Route.GYM.DAL.Models.HealthRecord;
using Route.GYM.DAL.Persistence.Data.Contexts;
using Route.GYM.DAL.Persistence.Repositories._Generic;

namespace Route.GYM.DAL.Persistence.Repositories.HealthRecords
{
    public class HealthRacordRepository : GenericRepository<HealthRecord>, IHealthRecordRebository
    {
        public HealthRacordRepository(GymDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
