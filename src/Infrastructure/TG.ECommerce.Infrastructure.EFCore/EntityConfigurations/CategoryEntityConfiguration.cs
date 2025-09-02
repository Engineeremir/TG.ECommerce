using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TG.ECommerce.Domain.AggregateModels.CategoryAggregate;

namespace TG.ECommerce.Infrastructure.EFCore.EntityConfigurations
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(t => t.Id);
            builder.Property(b => b.Id).HasColumnType("UUID").ValueGeneratedNever().IsRequired();

            builder.Property(c => c.Name).IsRequired().HasMaxLength(200);
            builder.HasIndex(c => c.Name).IsUnique().HasDatabaseName("IX_Categories_Name_Unique");
            builder.Property(x => x.CreatedOn).IsRequired();
        }
    }
}
