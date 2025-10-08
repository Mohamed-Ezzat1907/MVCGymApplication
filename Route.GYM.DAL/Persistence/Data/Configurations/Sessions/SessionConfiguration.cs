using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Route.GYM.DAL.Models.Session;

namespace Route.GYM.DAL.Persistence.Data.Configurations.Sessions
{
    internal class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.HasOne(s  => s.Trainer)
                   .WithMany(t => t.Sessions)
                   .HasForeignKey(s => s.TrainerId);

            builder.HasOne(s => s.Category)
                   .WithMany(c => c.Sessions)
                   .HasForeignKey(s => s.CategoryId);

            builder.ToTable(s =>
             {
                s.HasCheckConstraint("Session_Capacity_Check", "Capacity between 1 and 25");
                 s.HasCheckConstraint("Session_EndDate_Check", "EndDate > StartDate");
             });
        }
    }
}
