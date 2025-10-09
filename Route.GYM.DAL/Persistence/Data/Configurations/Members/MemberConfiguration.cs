using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Route.GYM.DAL.Models.HealthRecord;
using Route.GYM.DAL.Models.Member;
using Route.GYM.DAL.Persistence.Data.Configurations.GymUsers;

namespace Route.GYM.DAL.Persistence.Data.Configurations.Members
{
    public class MemberConfiguration : GymUserConfigration<Member> , IEntityTypeConfiguration<Member>
    {
        public new void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(m => m.CreatedAt)
                   .HasColumnName("JoinDate")
                   .HasDefaultValueSql("GETDATE()");

            builder.HasOne(m => m.HealthRecord)
                   .WithOne()
                   .HasForeignKey<HealthRecord>(hr => hr.Id);

            base.Configure(builder);
        }
    }
}
