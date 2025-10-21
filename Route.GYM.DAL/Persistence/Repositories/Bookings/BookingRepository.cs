using Route.GYM.DAL.Models.Booking;
using Route.GYM.DAL.Persistence.Data.Contexts;
using Route.GYM.DAL.Persistence.Repositories._Generic;

namespace Route.GYM.DAL.Persistence.Repositories.Bookings
{
    public class BookingRepository : GenericRepository<Booking> , IBookingRepository
    {
        public BookingRepository(GymDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
