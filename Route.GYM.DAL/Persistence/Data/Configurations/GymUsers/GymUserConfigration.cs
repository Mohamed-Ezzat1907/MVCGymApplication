using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Route.GYM.DAL.Models.GymUser;

namespace Route.GYM.DAL.Persistence.Data.Configurations.GymUsers
{
    public class GymUserConfigration : IEntityTypeConfiguration<GymUser> 
    {
        public void Configure(EntityTypeBuilder<GymUser> builder)
        {
            builder.Property(g => g.Name)
                   .HasColumnType("varchar")
                   .HasMaxLength(50);

            builder.Property(g => g.Email)
                   .HasColumnType("varchar")
                   .HasMaxLength(100);

            builder.Property(g => g.Phone)
                   .HasColumnType("varchar")
                   .HasMaxLength(11);

            builder.OwnsOne(g => g.Address, address =>
            {
                address.Property(a => a.BuidingNumber)
                       .HasColumnName("BuidingNumber");

                address.Property(a => a.Street)
                       .HasColumnName("Street")
                       .HasColumnType("varchar")
                       .HasMaxLength(30);

                address.Property(a => a.City)
                       .HasColumnName("City")
                       .HasColumnType("varchar")
                       .HasMaxLength(30);
            });

            builder.HasIndex(g => g.Email)
                   .IsUnique();

            builder.HasIndex(g => g.Phone)
                   .IsUnique();

            builder.ToTable(g =>
            {
                g.HasCheckConstraint("GymUser_EmailCheck", "Email LIKE '_%@_%._%'");
                g.HasCheckConstraint("GymUser_PhoneCheck", "Phone LIKE '01%' and Phone Not LIKE '%[^0-9]%'");
            });
        }
    }
}
