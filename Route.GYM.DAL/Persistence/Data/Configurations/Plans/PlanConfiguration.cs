using Microsoft.EntityFrameworkCore;

namespace Route.GYM.DAL.Persistence.Data.Configurations.Plans
{
    public class PlanConfiguration : IEntityTypeConfiguration<Models.Plan.plan>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Models.Plan.plan> builder)
        {
            builder.Property(p => p.Name)
                   .HasColumnType("varchar")
                   .HasMaxLength(50);

            builder.Property(p => p.Description)
                   .HasColumnType("varchar")
                   .HasMaxLength(200);

            builder.Property(p => p.Price)
                   .HasPrecision(10, 2);

            builder.ToTable(p => 
            {
                p.HasCheckConstraint("Plan_Duration_Check", "DurationDays Between 1 and 365");
            });

        }
    }
}
