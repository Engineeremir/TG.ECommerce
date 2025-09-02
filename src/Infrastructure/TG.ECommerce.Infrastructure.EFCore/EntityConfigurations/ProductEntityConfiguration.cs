using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TG.ECommerce.Domain.AggregateModels.ProductAggregate;

namespace TG.ECommerce.Infrastructure.EFCore.EntityConfigurations
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(t => t.Id);
            builder.Property(b => b.Id).HasColumnType("UUID").ValueGeneratedNever().IsRequired();

            builder.Property(b => b.Name).HasMaxLength(200);
            builder.Property(x => x.CreatedOn).IsRequired();
        }
    }
}
