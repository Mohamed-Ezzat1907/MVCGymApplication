using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Route.GYM.DAL.Models.Booking;

namespace Route.GYM.DAL.Persistence.Data.Configurations.Bookings
{
    internal class BookingCinfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
           builder.Ignore(b => b.Id);

            builder.Property(b => b.CreatedAt)
                   .HasColumnName("BookingDate")
                   .HasDefaultValueSql("GETDATE()");

            builder.HasOne(b => b.Session)
                   .WithMany(s => s.SessionMembers)
                   .HasForeignKey(b => b.SessionId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(b => b.Member)
                  .WithMany(s => s.MemberSessions)
                  .HasForeignKey(b => b.MemberId)
                  .OnDelete(DeleteBehavior.Cascade);

            builder.HasKey(b => new {b.MemberId , b.SessionId });
        }
    }
}
