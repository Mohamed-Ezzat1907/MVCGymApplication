using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Route.GYM.DAL.Models.HealthRecord;
using Route.GYM.DAL.Models.Member;

namespace Route.GYM.DAL.Persistence.Data.Configurations.Members
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(m => m.CreatedAt)
                   .HasColumnName("JoinDate")
                   .HasDefaultValueSql("GETDATE()");

            builder.HasOne(m => m.HealthRecord)
                   .WithOne()
                   .HasForeignKey<HealthRecord>(hr => hr.Id);
        }
    }
}
