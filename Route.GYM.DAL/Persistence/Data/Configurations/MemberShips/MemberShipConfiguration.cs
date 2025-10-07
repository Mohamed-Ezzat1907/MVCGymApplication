using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Route.GYM.DAL.Models.MemberShip;

namespace Route.GYM.DAL.Persistence.Data.Configurations.MemberShips
{
    internal class MemberShipConfiguration : IEntityTypeConfiguration<MemberShip>
    {
        public void Configure(EntityTypeBuilder<MemberShip> builder)
        {
            builder.Ignore(ms => ms.Id);

            builder.Property(ms => ms.CreatedAt)
                   .HasColumnName("StartDate")
                   .HasDefaultValueSql("GETDATE()");

            builder.HasOne(ms => ms.Plan)
                   .WithMany(ms => ms.PlanMembers)
                   .HasForeignKey(ms => ms.PlanId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ms => ms.Member)
                  .WithMany(ms => ms.MemberPlans)
                  .HasForeignKey(ms => ms.MemberId)
                  .OnDelete(DeleteBehavior.Cascade);

            builder.HasKey(ms => new { ms.MemberId, ms.PlanId });
        }
    }
}
