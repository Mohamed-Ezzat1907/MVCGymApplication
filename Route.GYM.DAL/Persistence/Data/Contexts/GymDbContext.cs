using Microsoft.EntityFrameworkCore;
using Route.GYM.DAL.Models.Booking;
using Route.GYM.DAL.Models.Category;
using Route.GYM.DAL.Models.HealthRecord;
using Route.GYM.DAL.Models.Member;
using Route.GYM.DAL.Models.MemberShip;
using Route.GYM.DAL.Models.Plan;
using Route.GYM.DAL.Models.Session;
using Route.GYM.DAL.Models.Trainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Route.GYM.DAL.Persistence.Data.Contexts
{
    public class GymDbContext : DbContext
    {
        #region Constructor

        public GymDbContext(DbContextOptions<GymDbContext> options) : base(options)
        {

        }

        #endregion

        #region Methods

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        } 

        #endregion

        #region DbSets

        public DbSet<Member> Members { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<MemberShip> MemberShips { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<HealthRecord> HealthRecords { get; set; }
        public DbSet<plan> plans { get; set; }


        #endregion
    }
}
