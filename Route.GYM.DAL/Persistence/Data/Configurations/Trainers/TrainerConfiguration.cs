using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Route.GYM.DAL.Models.Trainer;
using Route.GYM.DAL.Persistence.Data.Configurations.GymUsers;

namespace Route.GYM.DAL.Persistence.Data.Configurations.Trainers
{
    public class TrainerConfiguration : GymUserConfigration<Trainer> , IEntityTypeConfiguration<Trainer>
    {
        public new void Configure(EntityTypeBuilder<Trainer> builder)
        {
            builder.Property(t => t.CreatedAt)
                   .HasColumnName("HireDate")
                   .HasDefaultValueSql("GETDATE()");

            base.Configure(builder);
        }
    }
}
