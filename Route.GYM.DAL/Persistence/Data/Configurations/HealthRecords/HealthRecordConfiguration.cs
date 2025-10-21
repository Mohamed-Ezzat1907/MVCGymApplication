using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Route.GYM.DAL.Models.HealthRecord;

namespace Route.GYM.DAL.Persistence.Data.Configurations.HealthRecords
{
    internal class HealthRecordConfiguration : IEntityTypeConfiguration<HealthRecord>
    {
        public void Configure(EntityTypeBuilder<HealthRecord> builder)
        {
            builder.Ignore(hr => hr.CreatedAt);

            builder.Ignore(hr => hr.UpdatedAt);
        }
    }
}
