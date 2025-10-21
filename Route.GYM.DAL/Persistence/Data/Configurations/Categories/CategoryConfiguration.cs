using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Route.GYM.DAL.Models.Category;

namespace Route.GYM.DAL.Persistence.Data.Configurations.Categories
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.CategoryName)
                   .HasColumnType("varchar")
                   .HasMaxLength(20);
        }
    }
}
